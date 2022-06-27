using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjection.Currency
{
    public class Transaction
    {
        private readonly ICurrency _currency;

        public Transaction(ICurrency currency)
        {
            _currency = currency;

            DateOfTransaction = DateTimeOffset.Now;
        }
        public DateTimeOffset DateOfTransaction { get; private set; }

        public decimal GetTransactionAmount(){
            return _currency.Value;
        }

        public string GetTransactionName() => _currency.Name;

    }
}