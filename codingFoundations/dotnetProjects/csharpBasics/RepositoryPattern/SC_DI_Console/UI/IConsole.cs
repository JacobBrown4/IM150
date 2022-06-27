using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SC_DI_Console.UI
{
    public interface IConsole
    {
        void WriteLine(string s);
        void WriteLine(object o);
        void WriteLine();
        void Write(string s);
        void Clear();
        string ReadLine();
        ConsoleKeyInfo ReadKey();

    }

    public interface IConsoul{
        void WriteLine(string s);
    }
}