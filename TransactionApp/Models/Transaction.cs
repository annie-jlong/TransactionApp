using System;
namespace TransactionApp.Models
{
    public enum StatusCode
    {
        Approved,
        Failed,
        Rejected,
        Finished,
        Done
    }

    public class Transaction
    {
        public string TransactionIdentificator { get; set; }
        public decimal Amount { get; set; }
        public string CurrencyCode { get; set; }
        public DateTime TransactionDate { get; set; }
        public StatusCode Status { get; set; }
    }
}