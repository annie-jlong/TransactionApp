using System;
using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<Transaction> GetTransactions(string Currency, DateTime? DateFrom, DateTime? DateTo, string Status)
        {
            try
            {
                var query = _context.Transaction.ToList();

                if (!string.IsNullOrEmpty(Currency))
                {
                    query = query.Where(x => x.CurrencyCode == Currency).ToList();
                }

                if (DateFrom != null && DateTo != null)
                {
                    query = query.Where(x => x.TransactionDate <= DateTo && x.TransactionDate >= DateFrom).ToList();
                }

                if (!string.IsNullOrEmpty(Status))
                {
                    var statusCode = (StatusCode)Enum.Parse(typeof(StatusCode), Status);
                    query = query.Where(x => x.Status == statusCode).ToList();
                }
                return query;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
