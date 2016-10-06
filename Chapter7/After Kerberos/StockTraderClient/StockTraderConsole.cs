using System;
using System.Configuration;
using System.Security.Principal;

using Microsoft.Web.Services3.Security.Tokens;

namespace StockTraderClient
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class StockTraderConsole
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			StockTraderConsole client;

			try
			{
				client = new StockTraderConsole();
				client.Run();
			}
			catch (Exception ex)
			{
				Error( ex );
			}

			Console.WriteLine( "" );
			Console.WriteLine("Press [Enter] to continue...");
			Console.ReadLine();
		}

        // *************************************************************************************************
        // IMPORTANT: Please read the Chapter 7 section of the README.TXT file before running this solution.
        // It contains information about the environment setup for this sample.
        // *************************************************************************************************

        public void Run()
        {
            // Create an instance of the Web service proxy
            StockTraderProxy.StockTraderWse serviceProxy = new StockTraderProxy.StockTraderWse();

            // Use the logged in user identity as the identity of the current thread.
            AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);

            // Access the IIS based service
            serviceProxy.Url = "http://mauriciod/StockTraderSecure/StockTrader.asmx";

            // Use the credentials of the current security context
            serviceProxy.UseDefaultCredentials = true;

            // Set the client policy
            serviceProxy.SetPolicy("KerberosPolicy");

            // Call the service
            Console.WriteLine("Calling {0}", serviceProxy.Url);
            string Symbol = "MSFT";
            StockTraderProxy.Quote q = serviceProxy.RequestQuote(Symbol);

            // Show the results
            Console.WriteLine("Web Service Response:");
            Console.WriteLine("");
            Console.WriteLine("\tSymbol:\t\t" + q.Symbol);
            Console.WriteLine("\tCompany:\t" + q.Company);
            Console.WriteLine("\tLast Price:\t" + q.Last);
            Console.WriteLine("\tPrevious Close:\t" + q.Previous_Close);
        }

        protected static void Error(Exception ex)
        {
            Console.WriteLine("EXCEPTION!" + ex.Message + "\n" + ex.StackTrace);
        }
	}
}

