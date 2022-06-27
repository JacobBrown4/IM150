using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SC_DI_Console.UI
{
    public class MockConsole : IConsole
    {
        private readonly Random _random;

        public MockConsole()
        {
            _random = new Random();
        }

        public ConsoleColor RndColor()
        {
            int colorIndex = _random.Next(0, 16);
            return (ConsoleColor)colorIndex;
        }

        public void WriteLine(string s)
        {
            // sArCaStIc
            bool capitalize = false;
            foreach (char letter in s)
            {
                if (capitalize)
                {
                    Console.ForegroundColor = RndColor();
                    Console.Write(char.ToUpper(letter));
                    capitalize = false;
                }
                else
                {
                    Console.ForegroundColor = RndColor();
                    Console.Write(char.ToLower(letter));
                    capitalize = true;
                }
            }
            Thread.Sleep(50);
            Console.Write("\n");
        }

        public void WriteLine(object o)
        {
            Console.ForegroundColor = RndColor();
            Console.WriteLine(o);
        }

        public void WriteLine()
        {
            Console.WriteLine("vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv\n" +
            "\n" +
        "^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^\n");
        }

        public void Write(string s)
        {
            foreach (char letter in s)
            {
                Console.ForegroundColor = RndColor();
                Console.Write(letter);
            }
        }

        public void Clear()
        {
            Console.Clear();
            Console.BackgroundColor = RndColor();
        }

        public string ReadLine()
        {
            string input = Console.ReadLine();
            Console.WriteLine("Ummm.....");
            Thread.Sleep(1000);
            Console.WriteLine("You sure about that...?");
            Thread.Sleep(1500);
            Console.WriteLine(".....okay...");
            return input;
        }

        public ConsoleKeyInfo ReadKey()
        {
            Console.Beep(100, 1);
            return Console.ReadKey();
        }
        //Black 0//DarkBlue 1//DarkGreen 2//DarkCyan 3//DarkRed 4//DarkMagenta 5//DarkYellow 6//Gray 7//DarkGray 8//Blue 9//Green 10//Cyan 11//Red 12//Magenta 13//Yellow 14//White 15

    }
}