using System;
using System.Collections.Generic;
using TransactionApp.Models;

namespace TransactionApp.Services
{
    public interface ITransactionService
    {
        void SaveTransaction(IEnumerable<Transaction> transactions);
        IEnumerable<TransactionViewModel> GetAllTransactions();
        IEnumerable<TransactionViewModel> GetTransactions(string Currency, DateTime? DateFrom, DateTime? DateTo, string Status);
    }
}
