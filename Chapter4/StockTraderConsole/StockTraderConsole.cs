using System;
using System.Configuration;
using StockTraderTypes;

namespace StockTraderConsole
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

		public void Run()
		{
			// Create an instance of the Web service proxy
			StockConsoleProxy serviceProxy = new StockConsoleProxy();

			// Configure the proxy
			serviceProxy.Url = ConfigurationSettings.AppSettings["remoteHost"];

			// Call the service
			Console.WriteLine("Calling {0}", serviceProxy.Url);
			string Symbol = "MSFT";
			Quote q = serviceProxy.RequestQuote(Symbol);

			// Success!
			Console.WriteLine("Web Service Response:");
			Console.WriteLine("");
			Console.WriteLine( "\tSymbol:\t\t" + q.Symbol );
			Console.WriteLine( "\tCompany:\t" + q.Company );
			Console.WriteLine( "\tLast Price:\t" + q.Last );
			Console.WriteLine( "\tPrevious Close:\t" + q.Previous_Close );
		}

		protected static void Error(Exception ex)
		{
			Console.WriteLine("EXCEPTION!" + ex.Message);
		}
	}
}
