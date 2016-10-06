using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using Microsoft.Web.Services3;
using Microsoft.Web.Services3.Messaging;
using Microsoft.Web.Services3.Addressing;

using StockTraderTypes;

namespace StockTraderTcpSample
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class StockTrader : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Label label1;

		// Target URI
		private Uri receiverUri = null;

		public StockTrader()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			// Use TCP
			receiverUri = new Uri(String.Format("soap.tcp://{0}/StockTraderSoapReceiver", System.Net.Dns.GetHostName()));

			// Register the SOAP receiver objects
			StockTraderRequestReceiver request = new StockTraderRequestReceiver();
			SoapReceivers.Add(receiverUri, request);
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(24, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(376, 32);
			this.label1.TabIndex = 0;
			// 
			// StockTrader
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(416, 78);
			this.Controls.Add(this.label1);
			this.Name = "StockTrader";
			this.Text = "StockTraderSoapReceiver";
			this.Load += new System.EventHandler(this.StockTrader_Load);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new StockTrader());
		}

		private void StockTrader_Load(object sender, System.EventArgs e)
		{
			this.label1.Text = "Listening on " + String.Format("soap.tcp://{0}/StockTraderSoapReceiver", System.Net.Dns.GetHostName());
		}

	}

	// This class represents the Request Receiver (i.e., the service)
	public class StockTraderRequestReceiver : SoapReceiver
	{
		protected override void Receive(SoapEnvelope message)
		{
			if(message.Context.Addressing.Action.Value.EndsWith("RequestQuote"))
			{

				// Retrieve the body of the SOAP request message
				// Since we have screened the Action, we know what class to look for
				RequestQuote request = (RequestQuote)message.GetBodyObject(typeof(RequestQuote));
				string symbol = request.Symbol;

				// Call the RequestQuote() method: delegate the call to a business assembly
				Quote q = RequestQuote(symbol);

				// Transform the result into a SOAP response message
				SoapEnvelope response = new SoapEnvelope();
				response.SetBodyObject(q);

				// Create the URI address objects for send and receive
				// Note, instead of hardcoding the URIs, we will pull them from the original request message
				Uri toUri = (Uri)message.Context.Addressing.ReplyTo; // Send response to the request message's ReplyTo address
				Uri fromUri = (Uri)message.Context.Addressing.To; // Return response from the request message's To address

				// Assign the addressing SOAP message headers
				//response.Context.Addressing.Action = new Action(message.Context.Addressing.Action);
				response.Context.Addressing.Action = new Action("http://www.bluestonepartners.com/schemas/StockTrader/RequestQuote#Quote");
				response.Context.Addressing.From = new From(fromUri);
				//response.Context.Addressing.From = new Uri("soap.tcp://" + System.Net.Dns.GetHostName() + "/StockTraderSoapReceiver");
				SoapSender soapSender = new SoapSender(toUri);

				// Send the SOAP request message
				soapSender.Send(response);
			}

		}

		// This implementation of the RequestQuote() object should actually be centralized in a separate business assembly
		// The Receive() method could then call instantiate this assembly, and call the RequestQuote() method
		// However, for clarity, the RequestQuote() method is shown here as a private embedded method
		private Quote RequestQuote(string Symbol)
		{
			// Create a new Quote object
			Quote q = new Quote();
			if (Symbol.ToUpper() == "MSFT")
			{
				q.Symbol = Symbol; // Sample Quote
				q.Company = "Microsoft Corporation";
				q.DateTime = "11/17/2003 16:00:00";
				q.Last = 25.15;
				q.Previous_Close = 25.49;
				q.Change = -0.36;
				q.PercentChange = -0.0137;
			}
			else
			{
				q.Symbol = "INTC"; // Sample Quote
				q.Company = "Intel Corporation";
				q.DateTime = "11/17/2003 16:00:00";
				q.Last = 32.23;
				q.Previous_Close = 32.81;
				q.Change = -0.58;
				q.PercentChange = -0.0174;
			}
			return q; // Return a Quote object
		}
	}

}
