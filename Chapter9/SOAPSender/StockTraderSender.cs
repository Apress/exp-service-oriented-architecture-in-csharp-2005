
/*
	This code sample has been adapted from the WSE 2.0 QuickStart Projects
*/
using System;
using System.Text;

namespace StockTraderSender
{
	/// <summary>
	/// Summary description for StockTraderSecureClient.
	/// </summary>
	public class StockTraderSender
	{
		[STAThread]
		static void Main(string[] args)
		{
			StockTraderSender client = null;

			try
			{
				client = new StockTraderSender();

                // Send unencrypted request message
                client.SendUnsignedRequest();
			}
			catch (Exception e)
			{
				StringBuilder sb = new StringBuilder();
				if (e is System.Web.Services.Protocols.SoapException)
				{
					System.Web.Services.Protocols.SoapException se = e as System.Web.Services.Protocols.SoapException;
					sb.Append("SOAP-Fault code: " + se.Code.ToString());
					sb.Append("\n");
				}
				if (e != null)
				{
					sb.Append(e.ToString());
				}
				Console.WriteLine("*** Exception Raised ***");
				Console.WriteLine(sb.ToString());
				Console.WriteLine("************************");  
			}

			Console.WriteLine( "" );
			Console.WriteLine("Press [Enter] key to continue...");
			Console.ReadLine();
		}

		public void SendUnsignedRequest()
		{
			StockTraderServiceWse serviceProxy = new StockTraderServiceWse();

            // NOTE TO USER: Experiment with different ways to call the Web service, with and without routing
            // Open the StockTraderProxy.cs file to modify the Web service URI, inside the constructor StockTraderServiceWse()
            // For example, you can point the client directly to the Web service and bypass the SOAP router

			// Call the Web service RequestQuote() method
			Console.WriteLine("Calling {0}", serviceProxy.Url);
			Quote strQuote = serviceProxy.RequestQuote("MSFT");

			// Results
			Console.WriteLine("Web Service call successful. Result:");
			Console.WriteLine( " " );
			Console.WriteLine( "Symbol: " + strQuote.Symbol );
			Console.WriteLine( "Price:  " + strQuote.Last );
			Console.WriteLine( "Change: " + strQuote.PercentChange + "%");
		}
	}
}
