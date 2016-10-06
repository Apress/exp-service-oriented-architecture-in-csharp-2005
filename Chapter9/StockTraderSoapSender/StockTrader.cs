using System;
using System.Threading;

using Microsoft.Web.Services3;
using Microsoft.Web.Services3.Messaging;
using Microsoft.Web.Services3.Addressing;


using StockTraderTypes;

namespace StockTraderSoapClientConsole
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class StockTrader
	{
		/// <summary>
		/// The instance of the event signaled by receivers when
		/// responses are received.
		/// </summary>
		private static AutoResetEvent responseReceivedEventValue = new AutoResetEvent(false);

		/// <summary>
		/// This event is signaled when responses are received
		/// </summary>
		public static AutoResetEvent ResponseReceivedEvent
		{
			get
			{
				return responseReceivedEventValue;
			}
		}
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{

			StockTrader client = new StockTrader();
			client.Run();

			//
			// Wait for a receiver to signal that it received the response
			//
			if (ResponseReceivedEvent.WaitOne(new TimeSpan(0, 5, 0), false) == false)
			{
				Console.WriteLine("No response was received in five minutes.");
			}

			//
			// Wait for a final key press to close the application.
			//
			Console.WriteLine( "" );
			Console.WriteLine("Press [Enter] to continue...");
			Console.WriteLine( "" );
			Console.ReadLine();
			
		}

		public void Run()
		{

			// Send a request message for the RequestQuote() operation

			// Create a SOAP envelope with RequestQuote() in the Body
			SoapEnvelope message = new SoapEnvelope();
			RequestQuote request = new RequestQuote();
			request.Symbol = "MSFT";
			message.SetBodyObject(request);

			// Create the URI address objects for send and receive
			Uri toUri = new Uri("soap.tcp://" + System.Net.Dns.GetHostName() + "/StockTraderSoapReceiver");
			Uri fromUri = new Uri("soap.tcp://" + System.Net.Dns.GetHostName() + ":8082/StockTraderSoapSender");

			// Assign the addressing SOAP message headers
			message.Context.Addressing.Action = new Action( "http://www.bluestonepartners.com/schemas/StockTrader/RequestQuote");
			message.Context.Addressing.From = new From(fromUri);
			message.Context.Addressing.ReplyTo = new ReplyTo(fromUri);  
			SoapSender soapSender = new SoapSender(toUri);

			// Register the response receiver
			SoapReceivers.Add(fromUri, typeof(StockTraderResponseReceiver));

			// Send the SOAP request message
			soapSender.Send(message);

		}

	}

	// This class represents the Response Receiver (i.e., the client)
	public class StockTraderResponseReceiver : SoapReceiver
	{
		protected override void Receive( SoapEnvelope message )
		{
			if (message.Fault != null)
			{
				Console.WriteLine(message.Fault.ToString());
			}
			else 
			{
				if (message.Context.Addressing.Action.Value.EndsWith("RequestQuote#Quote"))
				{
					// Deserialize the message body into a Quote object
					// Since we have screened the Action, we know what class to look for
					Quote q = (Quote)message.GetBodyObject(typeof(Quote));
					string s = q.Symbol;
					Console.WriteLine("Quote for {0} was successfully retrieved", s);
				}
			}
			//
			// Set the event so the client knows we received the event
			//
			StockTrader.ResponseReceivedEvent.Set();

		}
	}
}
