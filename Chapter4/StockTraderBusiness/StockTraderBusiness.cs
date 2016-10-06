using System;
using StockTraderTypes;

namespace StockTraderBusiness
{
	/// <summary>
	/// Implements the business logic for StockTrader
	/// </summary>
	public class StockTraderBusiness : StockTraderTypes.IStockTrader
	{
		public StockTraderBusiness()
		{
		}

		//public override Quote RequestQuote(string Symbol)
		public Quote RequestQuote(string Symbol)
		{
			// There are 2 different implementations shown here:
			// #1: Generate quotes directly (simulating retrieval from a back-end system)
			// #2: Retrieve quotes using a Service Agent and the StockQuoteService external Web service

			// Create a new Quote object
			Quote q = new Quote();

			// Implementation #1:

			if (Symbol.ToUpper() == "MSFT")
			{
				q.Symbol = Symbol;
				q.Company = "Microsoft Corporation";
				q.DateTime = "11/17/2003 16:00:00";
				q.Last = 25.15;
				q.Previous_Close = 25.50;
				q.Change = -0.35;
				q.PercentChange = -0.0137;
			}
			else
			{
				q.Symbol = "INTC";
				q.Company = "Intel Corporation";
				q.DateTime = "11/17/2003 16:00:00";
				q.Last = 32.23;
				q.Previous_Close = 32.80;
				q.Change = -0.57;
				q.PercentChange = -0.0174;
			}
			
//			// Implementation #2: ServiceAgent (Uncomment the next 2 lines to implement the service agent)
//
//			StockTraderServiceAgent.StockTraderServiceAgent sa = new StockTraderServiceAgent.StockTraderServiceAgent();
//			q = sa.RequestQuote(Symbol);

			return q;
		}

		//public override Trade PlaceTrade(string Account, string Symbol, int Shares, Double Price, TradeType tradeType)
		public Trade PlaceTrade(string Account, string Symbol, int Shares, Double Price, TradeType tradeType)
		{
			Trade t = new Trade();
			t.TradeID = System.Guid.NewGuid().ToString();
			t.OrderDateTime = DateTime.Now.ToLongDateString();
			t.Symbol = Symbol;
			t.Shares = Shares;
			t.Price = Price;
			t.tradeType = tradeType;
			t.tradeStatus = TradeStatus.Ordered; // Initialize to Ordered
			// Persist trade details to the database by account number and trade ID
			return t;
		}

		//public override Trades TradeSummary(string Account)
		public Trades RequestAllTradesSummary(string Account)
		{
			// Lookup all current trades by account number
			// Return the results in a Trades object
			Trades t = new Trades();
			// Implement code here
			return t;
		}

		//public override Trade TradeDetail(string Account, string TradeID)
		public Trade RequestTradeDetails(string Account, string TradeID)
		{
			// Lookup the current trade by account number and Trade ID
			// Return the results in a Trade object
			Trade t = new Trade();
			t.TradeID = "123456";
			t.Symbol = "MSFT";
			t.Shares = 120;
			t.Price = 25.15;
			t.tradeType = TradeType.Bid;
			t.tradeStatus = TradeStatus.Filled;
			return t;
		}

	}
}
