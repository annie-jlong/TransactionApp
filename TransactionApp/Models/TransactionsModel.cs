using System;
using System.Collections.Generic;

namespace TransactionApp.Models
{
    public class TransactionsModel
    {
        public IList<TransactionViewModel> Transactions { get; set; }
    }
}
