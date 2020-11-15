using System;
using CsvHelper.Configuration;
using TransactionApp.Models;

namespace TransactionApp.Mappers
{
    public class TransactionMap : ClassMap<Transaction>
    {
        public TransactionMap() 
        {
            Map(x => x.TransactionIdentificator).Name("Id").Validate(field => !string.IsNullOrEmpty(field));
            Map(x => x.Amount).Name("Amount").Validate(field => !string.IsNullOrEmpty(field));
            Map(x => x.CurrencyCode).Name("Currency").Validate(field => !string.IsNullOrEmpty(field));
            Map(x => x.TransactionDate).Name("Date").Validate(field => !string.IsNullOrEmpty(field));
            Map(x => x.Status).Name("Status").Validate(field => !string.IsNullOrEmpty(field));
        }
    }
}
