using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using System.Configuration;
using System.Web.Services.Protocols;

using Microsoft.Web.Services3.Security;

namespace StockTraderClient
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class StockTraderClient : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label lblSymbol;
		private System.Windows.Forms.Label lblChange;
		private System.Windows.Forms.Label lblPreviousClose;
		private System.Windows.Forms.Label lblTradeDateTime;
		private System.Windows.Forms.Label lblLastTrade;
		private System.Windows.Forms.Label lblCompany;
		private System.Windows.Forms.Button btnQuote;
		private System.Windows.Forms.TextBox txtSymbol;
		private System.Windows.Forms.Button btnTrade;
		private System.Windows.Forms.Label lblConfirmation;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public StockTraderClient()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			btnTrade.Enabled = false;
			//
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
			this.btnQuote = new System.Windows.Forms.Button();
			this.txtSymbol = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.lblSymbol = new System.Windows.Forms.Label();
			this.lblChange = new System.Windows.Forms.Label();
			this.lblPreviousClose = new System.Windows.Forms.Label();
			this.lblTradeDateTime = new System.Windows.Forms.Label();
			this.lblLastTrade = new System.Windows.Forms.Label();
			this.lblCompany = new System.Windows.Forms.Label();
			this.btnTrade = new System.Windows.Forms.Button();
			this.lblConfirmation = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnQuote
			// 
			this.btnQuote.Location = new System.Drawing.Point(152, 24);
			this.btnQuote.Name = "btnQuote";
			this.btnQuote.Size = new System.Drawing.Size(128, 23);
			this.btnQuote.TabIndex = 1;
			this.btnQuote.Text = "Get Stock Quote";
			this.btnQuote.Click += new System.EventHandler(this.btnQuote_Click);
			// 
			// txtSymbol
			// 
			this.txtSymbol.Location = new System.Drawing.Point(24, 24);
			this.txtSymbol.Name = "txtSymbol";
			this.txtSymbol.Size = new System.Drawing.Size(112, 20);
			this.txtSymbol.TabIndex = 2;
			this.txtSymbol.Text = "MSFT";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(24, 80);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(104, 16);
			this.label1.TabIndex = 3;
			this.label1.Text = "Company:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(24, 128);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(104, 16);
			this.label2.TabIndex = 4;
			this.label2.Text = "Last Trade:";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(24, 152);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(104, 16);
			this.label3.TabIndex = 5;
			this.label3.Text = "Trade Date-Time:";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(24, 176);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(104, 16);
			this.label4.TabIndex = 6;
			this.label4.Text = "Previous Close:";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(24, 200);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(104, 16);
			this.label5.TabIndex = 7;
			this.label5.Text = "Change:";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(24, 104);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(104, 16);
			this.label6.TabIndex = 8;
			this.label6.Text = "Symbol:";
			// 
			// lblSymbol
			// 
			this.lblSymbol.Location = new System.Drawing.Point(144, 104);
			this.lblSymbol.Name = "lblSymbol";
			this.lblSymbol.Size = new System.Drawing.Size(280, 16);
			this.lblSymbol.TabIndex = 14;
			// 
			// lblChange
			// 
			this.lblChange.Location = new System.Drawing.Point(144, 200);
			this.lblChange.Name = "lblChange";
			this.lblChange.Size = new System.Drawing.Size(280, 16);
			this.lblChange.TabIndex = 13;
			// 
			// lblPreviousClose
			// 
			this.lblPreviousClose.Location = new System.Drawing.Point(144, 176);
			this.lblPreviousClose.Name = "lblPreviousClose";
			this.lblPreviousClose.Size = new System.Drawing.Size(280, 16);
			this.lblPreviousClose.TabIndex = 12;
			// 
			// lblTradeDateTime
			// 
			this.lblTradeDateTime.Location = new System.Drawing.Point(144, 152);
			this.lblTradeDateTime.Name = "lblTradeDateTime";
			this.lblTradeDateTime.Size = new System.Drawing.Size(280, 16);
			this.lblTradeDateTime.TabIndex = 11;
			// 
			// lblLastTrade
			// 
			this.lblLastTrade.Location = new System.Drawing.Point(144, 128);
			this.lblLastTrade.Name = "lblLastTrade";
			this.lblLastTrade.Size = new System.Drawing.Size(272, 16);
			this.lblLastTrade.TabIndex = 10;
			// 
			// lblCompany
			// 
			this.lblCompany.Location = new System.Drawing.Point(144, 80);
			this.lblCompany.Name = "lblCompany";
			this.lblCompany.Size = new System.Drawing.Size(280, 16);
			this.lblCompany.TabIndex = 9;
			// 
			// btnTrade
			// 
			this.btnTrade.Location = new System.Drawing.Point(296, 24);
			this.btnTrade.Name = "btnTrade";
			this.btnTrade.Size = new System.Drawing.Size(128, 23);
			this.btnTrade.TabIndex = 15;
			this.btnTrade.Text = "Trade Shares";
			this.btnTrade.Click += new System.EventHandler(this.btnTrade_Click);
			// 
			// lblConfirmation
			// 
			this.lblConfirmation.Location = new System.Drawing.Point(24, 240);
			this.lblConfirmation.Name = "lblConfirmation";
			this.lblConfirmation.Size = new System.Drawing.Size(456, 16);
			this.lblConfirmation.TabIndex = 16;
			// 
			// StockTraderClient
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(504, 273);
			this.Controls.Add(this.lblConfirmation);
			this.Controls.Add(this.btnTrade);
			this.Controls.Add(this.lblSymbol);
			this.Controls.Add(this.lblChange);
			this.Controls.Add(this.lblPreviousClose);
			this.Controls.Add(this.lblTradeDateTime);
			this.Controls.Add(this.lblLastTrade);
			this.Controls.Add(this.lblCompany);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtSymbol);
			this.Controls.Add(this.btnQuote);
			this.Name = "StockTraderClient";
			this.Text = "Stock Trader";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new StockTraderClient());
		}

		private void btnQuote_Click(object sender, System.EventArgs e)
		{
            // Note: Use Either Option 1 or Option 2 to call RequestQuote()
            // Each option uses a different service proxyfs

            //// Option 1: Call RequestQuote() using the Web References-generated Web service proxy
            //StockTrader.StockTrader serviceProxy = new StockTrader.StockTrader();
            //ConfigureProxy(serviceProxy);
            //StockTrader.Quote q = serviceProxy.RequestQuote(this.txtSymbol.Text);

            // Option 2: Call RequestQuote() using the wsdl.exe-generated Web service proxy
            StockTraderProxy.StockTraderProxy serviceProxy = new StockTraderProxy.StockTraderProxy();
            ConfigureProxy(serviceProxy);
            StockTraderProxy.Quote q = serviceProxy.RequestQuote(this.txtSymbol.Text);

            // Display the Quote results in the form
            this.lblCompany.Text = q.Company;
            this.lblSymbol.Text = q.Symbol;
            this.lblTradeDateTime.Text = q.DateTime;
            this.lblLastTrade.Text = q.Last.ToString();
            this.lblPreviousClose.Text = q.Previous_Close.ToString();
            this.lblChange.Text = q.Change.ToString();

            //// Enable the Trade button
            //btnTrade.Enabled = true;
		}

		private void btnTrade_Click(object sender, System.EventArgs e)
		{
            //// Create an instance of the Web service proxy
            //StockTraderProxy serviceProxy = new StockTraderProxy();

            //// Configure the proxy
            //ConfigureProxy(serviceProxy);

            //// Call the Web service to place a trade
            //Trade t = serviceProxy.PlaceTrade("1234", "MSFT", 20, 25.15, TradeType.Bid);

            //// Display a confirmation message with the trade details
            //string sTradeType = (t.tradeType == TradeType.Bid ? "Bid" : "Ask");
            //lblConfirmation.Text = t.OrderDateTime + ": " + sTradeType + " Trade placed for " + t.Shares + " shares of " + t.Symbol + " @ $" + t.Price + " per share."; 
		}

		protected void ConfigureProxy(HttpWebClientProtocol protocol)
		{
            protocol.Url = ConfigurationManager.AppSettings["remoteHost"];
		}

	}
}
