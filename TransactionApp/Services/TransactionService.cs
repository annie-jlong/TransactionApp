using System;
using System.Collections.Generic;
using TransactionApp.Models;

namespace TransactionApp.Services
{
    public class TransactionService: ITransactionService
    {
        private readonly TransactionDBContext _context;

        public TransactionService(TransactionDBContext context)
        {
            _context = context;
        }

        public void SaveTransaction(IEnumerable<Transaction> transactions)
        {
            try
            {
                foreach (var tran in transactions)
                {
                    _context.Add(tran);
                    _context.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public IEnumerable<Transaction> GetAllTransactions()
        {
           return _context.Transaction;
        }
    }
}
