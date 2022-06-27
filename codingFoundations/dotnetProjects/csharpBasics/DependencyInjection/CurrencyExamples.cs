using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DependencyInjection.Currency;

namespace DependencyInjection
{
    public class CurrencyExamples
    {
        private decimal _debt;
        public void TestingValues()
        {
            ICurrency penny = new Penny();
            System.Console.WriteLine($"This is a {penny.Name} it's worth {penny.Value}");
            ICurrency dime = new Dime();
            System.Console.WriteLine($"This is a {dime.Name} it's worth {dime.Value:C2}");
            ICurrency dollar = new Dollar();
            System.Console.WriteLine($"This is a {dollar.Name} it's worth {dollar.Value}");
            ICurrency ePay = new ElectronicPayment(43.34m);
            PrintInfo(ePay);
        }

        public void TestingTransaction()
        {
            _debt = 9000.01m;

            PayDebt(new Penny());
            PayDebt(new Dollar());
            System.Console.WriteLine(_debt);
            PayDebt(new ElectronicPayment(999m));
            System.Console.WriteLine(_debt);


            var firstTransaction = new Transaction(new Dollar());
            System.Console.WriteLine(firstTransaction.GetTransactionAmount());

            var ePay = new ElectronicPayment(500m);
            var secondTransaction = new Transaction(ePay);
            System.Console.WriteLine(secondTransaction.GetTransactionAmount());

            var list = new List<Transaction>{
                new Transaction(new Dollar()),
                new Transaction(new Dime()),
                new Transaction(new ElectronicPayment(4.34m)),
                new Transaction(new Penny())
            };

            foreach (var transaction in list)
            {
                System.Console.WriteLine($"{transaction.GetTransactionName()} {transaction.GetTransactionAmount():C2} Date: {transaction.DateOfTransaction}");
            }

        }

        public void PayDebt(ICurrency payment)
        {
            _debt -= payment.Value;
            System.Console.WriteLine($"You have paid {payment.Value:C2} towards your debt");
        }

        public void PrintInfo(ICurrency currency)
        {

            System.Console.WriteLine($"This is a {currency.Name} it's worth {currency.Value:C2}");
        }

    }
}