using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            char ans = 'y';
            while (ans != 'n')
            {
                try
                {

                    //Console.WriteLine("EndPoint:")
                    MyServiceClientNamespace_Console.MyServiceDllClient proxy = new ClientConsoleApp.MyServiceClientNamespace_Console.MyServiceDllClient();
                    Console.Write("\nEnter a message for Marco's PC: ");
                    string s = Console.ReadLine();
                    Console.WriteLine("\nMarco's PC says:");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n{0}", proxy.MessageBack(s));
                    Console.ForegroundColor = ConsoleColor.Gray;
                    //Console.WriteLine("\nEnter a number:");
                    //double d = Console.ReadLine();
                    Console.WriteLine("\nContinue? [y/n] ");
                    ans = Console.ReadKey(true).KeyChar;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\nError: {0}", ex.Message);
                }
            }
        }
    }
}
