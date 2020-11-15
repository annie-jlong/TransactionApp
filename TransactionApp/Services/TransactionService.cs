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

        public IEnumerable<TransactionViewModel> GetAllTransactions()
        {
           return _context.Transaction.ToList().Select(x => { return x.toTransactionViewModel(); });
        }

        public IEnumerable<TransactionViewModel> GetTransactions(string Currency, DateTime? DateFrom, DateTime? DateTo, string Status)
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

                StatusCode statusCode=StatusCode.Approved;
                bool bStatus = false;
                if (!string.IsNullOrEmpty(Status))
                {
                    object obj;
                    bStatus = Enum.TryParse(typeof(StatusCode), Status, out obj);
                    if (bStatus)
                        statusCode = (StatusCode)Enum.Parse(typeof(StatusCode), Status); 
                }

                if (bStatus)
                {
                    query = query.Where(x => x.Status == statusCode).ToList();
                }

                var res = query.Select(x => { return x.toTransactionViewModel(); });
                return res;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
