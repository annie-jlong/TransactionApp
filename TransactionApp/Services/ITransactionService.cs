using System;
using System.Collections.Generic;
using TransactionApp.Models;

namespace TransactionApp.Services
{
    public interface ITransactionService
    {
        void SaveTransaction(IEnumerable<Transaction> transactions);
        IEnumerable<Transaction> GetAllTransactions();
    }
}
