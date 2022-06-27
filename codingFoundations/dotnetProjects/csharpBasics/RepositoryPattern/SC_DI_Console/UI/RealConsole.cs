using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SC_DI_Console.UI
{
    
    public class RealConsole : IConsole,IConsoul
    {
        // How to implement two methods from different interfaces
        public void IConsole.WriteLine(string s){
            Console.WriteLine(s);
        }

        public void IConsoul.WriteLine(string s){
            System.Console.WriteLine("You have a soul");
        }
        public void WriteLine(object o){
            Console.WriteLine(o);
        }

        public void WriteLine(){
            Console.WriteLine();
        }

        public void Write(string s){
            Console.Write(s);
        }

        public void Clear(){
            Console.Clear();
        }

        public string ReadLine(){
            return Console.ReadLine();
        }

        public ConsoleKeyInfo ReadKey(){
            return Console.ReadKey();
        }
        
    }
}