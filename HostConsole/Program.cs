using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
//using MyServiceDll;

namespace HostConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            using (ServiceHost myserviceHost = new ServiceHost(typeof(MyServiceDll.MyServiceDll)))
            {
                myserviceHost.Open();

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n\nPress ENTER to terminate MyService host application\n");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("\nService name:             {0}", myserviceHost.Description.Name);
                Console.WriteLine("\nService base address:     {0}", myserviceHost.BaseAddresses[0].AbsoluteUri);
                Console.WriteLine("\nService endpoint name:    {0}", myserviceHost.Description.Endpoints[0].Name);
                Console.WriteLine("\nService endpoint address: {0}", myserviceHost.Description.Endpoints[0].Address.Uri.AbsoluteUri);
                Console.WriteLine("\nService endpoint binding: {0}", myserviceHost.Description.Endpoints[0].Binding);
                Console.WriteLine("\nService timeout:          {0}", myserviceHost.CloseTimeout);
                Console.WriteLine("\nService status:           {0}\n", myserviceHost.State);

                Console.ReadLine();
            }

        }
    }
}
