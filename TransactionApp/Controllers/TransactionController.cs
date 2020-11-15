using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TransactionApp.Models;
using TransactionApp.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TransactionApp.Controllers
{
    [Route("api/[controller]")]
    public class TransactionController : Controller
    {
        private readonly ITransactionService _transactionService;
        private readonly ILogger<TransactionController> _logger;

        public TransactionController(ITransactionService transactionService, ILogger<TransactionController> logger)
        {
            _transactionService = transactionService;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Transaction> Get([FromQuery]QueryParam param)
        {
            try
            {
                var currency = param.Currency;
                var dateFrom = param.DateFrom;
                var dateTo = param.DateTo;
                var status = param.Status;

                return _transactionService.GetTransactions(currency, dateFrom, dateTo, status);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
