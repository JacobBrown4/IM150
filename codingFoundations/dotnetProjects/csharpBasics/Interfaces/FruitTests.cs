using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Interfaces.Fruits;

namespace Interfaces
{
    public class FruitTests
    {
        public void Run()
        {
            IFruit banana = new Banana();
            string output = banana.Peel();
            System.Console.WriteLine(banana.IsPeeled);
            System.Console.WriteLine(output);
            System.Console.WriteLine("The banana is peeled: " + banana.IsPeeled);

            var orange = new Orange();
            var fruitSalad = new List<IFruit>
            {
                new Banana(),
                new Grape(),
                orange,
                new Grape(),
                new Banana(true),
                new Orange(true),
                new Banana()
            };

            foreach (var fruit in fruitSalad)
            {
                System.Console.WriteLine(fruit.Name);
                System.Console.WriteLine(fruit.Peel());

                // fruit.Squeeze() <Inaccessible when still being treated as an IFruit type
            }
            System.Console.WriteLine(orange.Squeeze());

            foreach (var fruit in fruitSalad)
            {
                if (fruit is Orange orangeType) // Pattern matching with 'is' struct
                {
                    if (orangeType.IsPeeled)
                    {

                        System.Console.WriteLine("It's a peeled Orange");
                        System.Console.WriteLine(orangeType.Squeeze());
                    }
                    else
                        System.Console.WriteLine("It's an orange");
                }
                else if (fruit.GetType() == typeof(Grape))
                { // I know it's a grape here, but not being treated as one
                    System.Console.WriteLine("It's a grape.");

                    // Since I know the class is Grape to even be here I'm allowed a free casting
                    var grape = (Grape)fruit; //Casting, lazy converts into a new class
                    System.Console.WriteLine(grape.Peel());
                }
                else if (fruit.IsPeeled)
                {
                    System.Console.WriteLine("It's a peeled a banana");
                }
                else
                    System.Console.WriteLine("Is a banana");

            }

        }
    }
}