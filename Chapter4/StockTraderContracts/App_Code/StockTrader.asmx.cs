using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Services.Description;

using StockTraderTypes;
using StockTraderBusiness;

namespace StockTraderContracts
{
	/// <summary>
	/// Summary description for StockTrader.
	/// </summary>
	public class StockTrader : System.Web.Services.WebService, StockTraderTypes.IStockTrader
	{
		[WebMethod()]
		[SoapDocumentMethod(RequestNamespace="http://www.bluestonepartners.com/schemas/StockTrader/", ResponseNamespace="http://www.bluestonepartners.com/schemas/StockTrader/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Bare)]
		[return: System.Xml.Serialization.XmlElement("Quote", Namespace = "http://www.bluestonepartners.com/schemas/StockTrader/")]
		public Quote RequestQuote(string Symbol)
		{
			StockTraderBusiness.StockTraderBusiness b = new StockTraderBusiness.StockTraderBusiness();
			Quote q = b.RequestQuote(Symbol);
			return q;
		}

		[WebMethod()]
		[SoapDocumentMethod(RequestNamespace="http://www.bluestonepartners.com/schemas/StockTrader/", ResponseNamespace="http://www.bluestonepartners.com/schemas/StockTrader/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Bare)]
		[return: System.Xml.Serialization.XmlElement("Trade", Namespace = "http://www.bluestonepartners.com/schemas/StockTrader/")]
		public Trade PlaceTrade(string Account, string Symbol, int Shares, System.Double Price, TradeType tradeType)
		{
			return null;
		}

		[WebMethod()]
		[SoapDocumentMethod(RequestNamespace="http://www.bluestonepartners.com/schemas/StockTrader/", ResponseNamespace="http://www.bluestonepartners.com/schemas/StockTrader/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Bare)]
		[return: System.Xml.Serialization.XmlElement("Trade", Namespace = "http://www.bluestonepartners.com/schemas/StockTrader/")]
		public Trade RequestTradeDetails(string Account, string TradeID)
		{
			return null;
		}

		[WebMethod()]
		[SoapDocumentMethod(RequestNamespace="http://www.bluestonepartners.com/schemas/StockTrader/", ResponseNamespace="http://www.bluestonepartners.com/schemas/StockTrader/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Bare)]
		[return: System.Xml.Serialization.XmlElement("Trades", Namespace = "http://www.bluestonepartners.com/schemas/StockTrader/")]
		public Trades RequestAllTradesSummary(string Account)
		{
			return null;
		}
	}
}

