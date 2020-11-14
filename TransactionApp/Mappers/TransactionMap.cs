using System;
using CsvHelper.Configuration;
using TransactionApp.Models;

namespace TransactionApp.Mappers
{
    public class TransactionMap : ClassMap<Transaction>
    {
        public TransactionMap() 
        {
            Map(x => x.TransactionIdentificator).Name("Id");
            Map(x => x.Amount).Name("Amount");
            Map(x => x.CurrencyCode).Name("Currency");
            Map(x => x.TransactionDate).Name("Date");
            Map(x => x.Status).Name("Status");
        }
    }
}
