using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjection.Currency
{
    public class Penny : ICurrency
    {
        public string Name
        {
            get { return "Penny"; }
        }

        public decimal Value
        {
            get { return 0.01m; }
        }
    }

    public class Dime : ICurrency
    {
        public string Name => "Dime";
        public decimal Value => 0.1m;
    }

    public class Dollar : ICurrency
    {
        public string Name => "Dollar";
        public decimal Value => 1m;
    }

    public class ElectronicPayment : ICurrency
    {
        // Without a set or private set on a value,
        // We can only set the value when using a constructor.
        // Since we added a constructor the implicit empty constructor is gone
        //public ElectronicPayment() {}
        public ElectronicPayment(decimal value)
        {
            Value = value;
        }
        public string Name => "Electronc Payment";

        public decimal Value { get; }
    }
}