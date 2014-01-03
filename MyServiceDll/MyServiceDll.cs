using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MyServiceDll
{
    // NOTE: If you change the class name "Service1" here, you must also update the reference to "Service1" in App.config.
    public class MyServiceDll : IMyServiceDll
    {
        public string MessageBack(string fromClient)
        {
            Console.Write("\nThe client has written: ");      //NB: mixing hosting code and service code like here should be always AVOIDED!
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("'{0}'\n", fromClient);
            Console.ForegroundColor = ConsoleColor.Gray;
            //txtBoxSend.t
            //Console.Write("Enter your reply: ");
            //string s = Console.ReadLine();
            //return string.Format("You have written: '{0}'\nMarco's PC says: {1}", fromClient, s);
            return string.Format("You have written: '{0}'\n", fromClient);
        }

        public double RemoteCalc(double num)
        {
            return num * num;
        }

        }
}
