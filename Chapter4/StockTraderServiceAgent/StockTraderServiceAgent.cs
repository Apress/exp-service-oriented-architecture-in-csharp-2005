using System;
using StockTraderServiceAgent;
using StockTraderTypes;

namespace StockTraderServiceAgent
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class StockTraderServiceAgent : StockTraderTypes.IStockTrader
	{
		public StockTraderServiceAgent(){}

		public Quote RequestQuote(string Symbol)
		{
			Quote q = null;

			// Request a Quote from the external service
			QuoteExt qe;
			StockQuoteService serviceProxy = new StockQuoteService();
			qe = serviceProxy.RequestQuoteExt("MSFT");

			// Create a local Quote object (from the StockTraderTypes namespace)
			q = new Quote();

			// Map the external QuoteExt object to the local Quote object
			// This requires some manual work because the types do not map exactly to eachother
			q.Symbol = Symbol;
			q.Company = qe.Company_Ext;
			q.DateTime = qe.DateTime_Ext.ToString("mm/dd/yyyy hh:mm:ss");
			q.High = qe.High_Ext;
			q.Low = qe.Low_Ext;
			q.Open = qe.Open_Ext;
			q.Last = qe.Last_Ext;
			q.Previous_Close = qe.Previous_Close_Ext;
			q.Change = (qe.Last_Ext - qe.Open_Ext);
			q.PercentChange = q.Change/q.Last;
			q.High_52_Week = qe.High_52_Week_Ext;
			q.Low_52_Week = qe.Low_52_Week_Ext;

			return q;
		}

		public Trade PlaceTrade(string Account, string Symbol, int Shares, Double Price, TradeType tradeType)
		{
			return null;
		}

		public Trades RequestAllTradesSummary(string Account)
		{
			return null;
		}

		public Trade RequestTradeDetails(string Account, string TradeID)
		{
			return null;
		}
	}
}
