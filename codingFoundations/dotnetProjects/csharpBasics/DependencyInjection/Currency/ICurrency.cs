using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjection.Currency
{
    public interface ICurrency
    {
        string Name {get;}
        decimal Value {get;}
    }
}