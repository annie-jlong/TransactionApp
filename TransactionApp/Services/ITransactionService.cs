using System;
using System.Collections.Generic;
using TransactionApp.Models;

namespace TransactionApp.Services
{
    public interface ITransactionService
    {
        void SaveTransaction(IEnumerable<Transaction> transactions);
        IEnumerable<Transaction> GetAllTransactions();
        IEnumerable<Transaction> GetTransactions(string Currency, DateTime? DateFrom, DateTime? DateTo, string Status);
    }
}
