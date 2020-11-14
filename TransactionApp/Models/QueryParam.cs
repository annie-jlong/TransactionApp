using System;
namespace TransactionApp.Models
{
    public class QueryParam
    {
        public string Currency { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public string Status { get; set; }
    }
}
