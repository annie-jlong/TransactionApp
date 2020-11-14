using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TransactionApp.Mappers;
using TransactionApp.Models;

namespace TransactionApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly TransactionDBContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(TransactionDBContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UploadFile(FileModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(viewName: "Index");
                }

                var extension = Path.GetExtension(model.FileUpload.FileName);
                var stream = model.FileUpload.OpenReadStream();
                var reader = new StreamReader(stream);

                IEnumerable<Transaction> trans=null;
                if (extension==".csv")
                {
                    trans = ReadCSV(reader);
                }
                else
                {
                    trans = ReadXML(reader);
                }

                if (trans != null)
                {
                    foreach(var tran in trans)
                    {
                        _context.Add(tran);
                        _context.SaveChanges();
                    }
                    var resModel = new TransactionsModel();
                    resModel.Transactions = trans.ToList();

                    return View(viewName:"TransactionList",resModel);
                }
                else
                    return View(viewName:"Index");
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                ModelState.AddModelError("FileUpload", ex.Message);
                return View(viewName: "Index");
            }
        }

        private IEnumerable<Transaction> ReadCSV(StreamReader reader)
        {
            try
            {
                using (var csv = new CsvReader(reader, System.Globalization.CultureInfo.CurrentCulture))
                {
                    csv.Configuration.RegisterClassMap<TransactionMap>();
                    var records = csv.GetRecords<Transaction>().ToList();
                    return records;
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                ModelState.AddModelError("FileUpload", ex.Message);
                return null;
            }
        }

        private IEnumerable<Transaction> ReadXML(StreamReader reader)
        {
            try
            {
                List<Transaction> transactions = new List<Transaction>();
              
                XElement group = XElement.Load(reader);
                
                var query = group.Descendants("Transaction");
                foreach (var tran in query)
                {
                    var transaction = new Transaction();
                    transaction.TransactionIdentificator = tran.Attribute("id").Value;
                    foreach (var node in tran.Descendants())
                    {
                        if (node.NodeType == XmlNodeType.Element && node.Name == "TransactionDate")
                        {
                            transaction.TransactionDate = DateTime.Parse(node.Value);
                        }
                        if (node.NodeType == XmlNodeType.Element && node.Name == "Amount")
                        {
                            transaction.Amount = Decimal.Parse(node.Value);
                        }
                        if (node.NodeType == XmlNodeType.Element && node.Name == "CurrencyCode")
                        {
                            transaction.CurrencyCode = node.Value;
                        }
                        if (node.NodeType == XmlNodeType.Element && node.Name == "Status")
                        {
                            transaction.Status = (StatusCode)Enum.Parse(typeof(StatusCode), node.Value);
                        }
                        
                    }
                    //tran.Descendants().Select(x => {
                        
                    //});
                    transactions.Add(transaction);
                }

                return transactions;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                ModelState.AddModelError("FileUpload", ex.Message);
                return null;
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
