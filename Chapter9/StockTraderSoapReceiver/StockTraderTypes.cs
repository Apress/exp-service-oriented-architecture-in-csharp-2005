using System;
using System.Xml.Serialization;

namespace StockTraderTypes
{
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.bluestonepartners.com/schemas/StockTrader/")]
	public class RequestQuote
	{
		public String Symbol;
	}

	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.bluestonepartners.com/schemas/StockTrader/")]
	public class Quote
	{
		public string Symbol;
    
		public string Company;

		public string DateTime;

		public System.Double High;
    
		public System.Double Low;

		public System.Double Open;
    
		public System.Double Last;
    
		public System.Double Change;
    
		public System.Double PercentChange;
    
		public System.Double Previous_Close;

		public System.Double High_52_Week;

		public System.Double Low_52_Week;
	}

	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.bluestonepartners.com/schemas/StockTrader/")]
	public class Trade 
	{
		public string TradeID;

		public string Symbol;

		public System.Double Price;

		public int Shares;

		public TradeType tradeType;

		public TradeStatus tradeStatus;
    
		public string OrderDateTime;

		public string LastActivityDateTime;
	}

	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.bluestonepartners.com/schemas/StockTrader/")]
	public class Trades 
	{
		public string Account;
    
		public Trade[] Bids;
    
		public Trade[] Asks;
	}

	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.bluestonepartners.com/schemas/StockTrader/")]
	public enum TradeStatus
	{
		Ordered,
		Filled,
		Cancelled,
		Unfilled,
	}

	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.bluestonepartners.com/schemas/StockTrader/")]
	public enum TradeType
	{
		Bid,
		Ask
	}
}


