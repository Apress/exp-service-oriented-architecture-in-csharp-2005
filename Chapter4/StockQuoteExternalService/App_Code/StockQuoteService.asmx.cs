using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Services.Description;
using System.Xml.Serialization;

namespace StockQuoteExternalService
{
	/// <summary>
	/// Summary description for StockQuoteService.
	/// </summary>
	public class StockQuoteService : System.Web.Services.WebService
	{
		public StockQuoteService()
		{
			//CODEGEN: This call is required by the ASP.NET Web Services Designer
			InitializeComponent();
		}

		[WebMethod()]
		[SoapDocumentMethod(RequestNamespace="http://www.bluestonepartners.com/schemas/StockTraderExt/", ResponseNamespace="http://www.bluestonepartners.com/schemas/StockTraderExt/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Bare)]
		[return: XmlElement("QuoteExt", Namespace = "http://www.bluestonepartners.com/schemas/StockTraderExt/")]
		public QuoteExt RequestQuoteExt(string SymbolExt)
		{
			// Create a new Quote object
			QuoteExt q = new QuoteExt();
			if (SymbolExt.ToUpper() == "MSFT")
			{
				q.Company_Ext = "Microsoft Corporation";
				q.DateTime_Ext = new DateTime(2003,11,17,16,0,0);
				q.Last_Ext = 25.15;
				q.Previous_Close_Ext = 25.50;
			}
			else
			{
				q.Company_Ext = "Intel Corporation";
				q.DateTime_Ext = new DateTime(2003,11,17,16,0,0);
				q.Last_Ext = 32.23;
				q.Previous_Close_Ext = 32.80;
			}
			return q;
		}

		#region Component Designer generated code
		
		//Required by the Web Services Designer 
		private IContainer components = null;
				
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if(disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);		
		}
		
		#endregion

		public class QuoteExt
		{
			public string Company_Ext;

			public System.DateTime DateTime_Ext;

			public System.Double High_Ext;
    
			public System.Double Low_Ext;

			public System.Double Open_Ext;
    
			public System.Double Last_Ext;
    
			public System.Double Previous_Close_Ext;

			public System.Double High_52_Week_Ext;

			public System.Double Low_52_Week_Ext;
		}

	}
}
