using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TransactionApp.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TransactionApp.Controllers
{
    [Route("api/[controller]")]
    public class TransactionController : Controller
    {
        

        public TransactionController()
        {
            
        }

        // GET: /<controller>/
        public IEnumerable<Transaction> GetTransactionList()
        {
            return null;
        }
    }
}
