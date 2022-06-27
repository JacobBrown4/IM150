using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SC_DI_Console.UI
{
    public class SlowConsole : IConsole
    {
        private readonly Random _rnd;

        public SlowConsole()
        {
            _rnd = new Random();
        }

        public int Random()
        {
            return _rnd.Next(100, 800);
        }
        public void Write(string s)
        {
            foreach (char letter in s)
            {
                Thread.Sleep(30);
                Console.Beep(Random(), 30);
                Console.Write(letter);
            }
        }
        public void Write(char a)
        {
            Thread.Sleep(30);
            Console.Beep(Random(), 30);
            Console.Write(a);
        }
        
        public void WriteLine(string s)
        {
            Write(s);
            Console.Write("\n");
        }

        public void WriteLine(object o)
        {
            Console.WriteLine(o);
        }

        public void WriteLine()
        {
            Console.WriteLine();
        }

        public void Clear()
        {
            Thread.Sleep(50);
            Console.Beep(100, 100);
            Console.Clear();
        }

        public string ReadLine()
        {
            var input = Console.ReadLine();
            foreach (char letter in "...........")
            {
                Write(letter);

            }
            return input;
        }

        public ConsoleKeyInfo ReadKey()
        {
            var input = Console.ReadKey();
            foreach (var letter in ".......")
            {
                Write(letter);
            }
            return input;
        }

    }
}