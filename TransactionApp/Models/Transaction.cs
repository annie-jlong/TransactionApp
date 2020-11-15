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
        public decimal? Amount { get; set; }
        public string CurrencyCode { get; set; }
        public DateTime? TransactionDate { get; set; }
        public StatusCode? Status { get; set; }

        public bool IsValid()
        {
            return !string.IsNullOrEmpty(TransactionIdentificator) &&
                Amount != null && !string.IsNullOrEmpty(CurrencyCode) && TransactionDate != null && Status != null;
        }

        public TransactionViewModel toTransactionViewModel()
        {
            string status = string.Empty;
            switch (this.Status.Value)
            {
                case StatusCode.Approved:
                    status = "A";
                    break;
                case StatusCode.Rejected:
                    status = "R";
                    break;
                case StatusCode.Failed:
                    status = "R";
                    break;
                case StatusCode.Finished:
                    status = "D";
                    break;
                case StatusCode.Done:
                    status = "D";
                    break;
            }
            return new TransactionViewModel
            {
                Id = this.TransactionIdentificator,
                Payment = $"{ this.Amount.Value:0.00} {this.CurrencyCode}",
                Status = status
            };
        }
    }
}