using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml;
using System.Xml.Serialization;
using System.Collections;

using Microsoft.Web.Services3;
using Microsoft.Web.Services3.Security.Tokens;

namespace StockTrader
{
    [WebService(Namespace = "http://www.bluestonepartners.com/schemas/StockTrader/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [Policy("UsernamePolicy")]
    public class StockTrader : StockTraderStub 
    {
        public StockTrader()
        {
            //Uncomment the following line if using designed components 
            //InitializeComponent(); 
        }

        [WebMethod]
        [return: XmlElement(ElementName = "Quote", Namespace = "http://www.bluestonepartners.com/schemas/StockTrader/")]
        public override Quote RequestQuote(string Symbol)
        {

            // Check if the user is authorized to access this method
            authorize();

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

//				// Test Exception Code
//				XmlDocument doc = new XmlDocument();
//				XmlNode node = doc.CreateNode(XmlNodeType.Element, SoapException.DetailElementName.Name, SoapException.DetailElementName.Namespace);
//				throw new SoapException("Test", SoapException.ClientFaultCode,Context.Request.Url.AbsoluteUri, node);
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

        [WebMethod]
        [return: XmlElement(ElementName = "Trade", Namespace = "http://www.bluestonepartners.com/schemas/StockTrader/")]
        public override Trade PlaceTrade(string Account, string Symbol, int Shares, System.Double Price, TradeType tradeType)
        {
            Trade t = new Trade();
            t.TradeID = System.Guid.NewGuid().ToString();
            t.OrderDateTime = "11/17/2003 18:30:00";
            t.Symbol = Symbol;
            t.Shares = Shares;
            t.Price = Price;
            t.tradeType = tradeType;
            t.tradeStatus = TradeStatus.Ordered; // Initialize Trade status to Ordered

            // Implement code here to persist trade details to the database by account number and trade ID
            // <-- Code goes here -->

            return t; // Return the Trade object
        }

        [WebMethod]
        [return: XmlElement(ElementName = "Trade", Namespace = "http://www.bluestonepartners.com/schemas/StockTrader/")]
        public override Trade RequestTradeDetails(string Account, string TradeID)
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

        [WebMethod]
        [return: XmlElement(ElementName = "Trades", Namespace = "http://www.bluestonepartners.com/schemas/StockTrader/")]
        public override Trades RequestAllTradesSummary(string Account)
        {
            // Return a Trades object that summarizes all Bid and Ask trades for the current account number
            // Lookup all current trades by account number
            // Return the results in a Trades object
            Trades t = new Trades();
            t.Account = Account; // Assign the current account number

            ArrayList arrBids = new ArrayList();
            ArrayList arrAsks = new ArrayList();

            // Implement code here to retrieve all trades from the database
            // <-- Code goes here -->

            Trade t1 = new Trade(); // Sample Bid Trade
            t1.tradeType = TradeType.Bid;
            t1.Symbol = "MSFT";
            t1.Shares = 120;
            t1.Price = 25.15;
            t1.tradeStatus = TradeStatus.Filled;
            arrBids.Add(t1);

            Trade t2 = new Trade(); // Sample Ask Trade
            t1.tradeType = TradeType.Ask;
            t1.Symbol = "INTC";
            t1.Shares = 80;
            t1.Price = 32.23;
            t1.tradeStatus = TradeStatus.Filled;
            arrAsks.Add(t2);

            t.Bids = (Trade[])arrBids.ToArray(typeof(Trade)); // Transfer the arraylist of Bids to the Trades object's Bids collection
            t.Asks = (Trade[])arrAsks.ToArray(typeof(Trade)); // Transfer the arraylist of Asks to the Trades object's Asks collection

            return t; // Return the Trades object
        }

        private void authorize()
        {

            string username = RequestSoapContext.Current.Credentials.UltimateReceiver.GetClientToken<UsernameToken>().Username;

            if (username == "admin")
            {
                return;
            }
            else
            {
                throw new SoapException("Access denied.",
                         new XmlQualifiedName("Authorization"));
            }

        }
    }
}
