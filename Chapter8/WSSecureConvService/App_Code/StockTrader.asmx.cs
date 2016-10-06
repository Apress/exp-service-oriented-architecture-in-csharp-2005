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

using Microsoft.Web.Services3;
using Microsoft.Web.Services3.Security;
using Microsoft.Web.Services3.Security.Tokens;

using System.Security.Permissions;

using StockTraderTypes;

namespace WSSecureConvService
{
	/// <summary>
	/// Summary description for StockTraderService
	/// </summary>
	[WebService(Namespace = "http://www.bluestonepartners.com/schemas/StockTrader")]
	public class StockTraderService : System.Web.Services.WebService, StockTraderTypes.IStockTrader
	{
	
		[WebMethod()]
		[SoapDocumentMethod(RequestNamespace="http://www.bluestonepartners.com/schemas/StockTrader/", ResponseNamespace="http://www.bluestonepartners.com/schemas/StockTrader/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Bare)]
		[return: XmlElement(ElementName = "Quote", Namespace = "http://www.bluestonepartners.com/schemas/StockTrader/")]
		public Quote RequestQuote(string Symbol)
		{
			// Reject any requests which are not valid SOAP requests
			SoapContext requestContext = RequestSoapContext.Current;
			if (requestContext == null)
			{
				throw new ApplicationException("Only SOAP requests are permitted.");
			}

			// Check if the Soap Message is Signed.
			SecurityContextToken sct = GetSigningToken(requestContext) as SecurityContextToken;
			if (sct == null)
			{
				throw new ApplicationException("The request is not signed with an SCT.");
			}

			// Check if the Soap Message is Encrypted.
			if (!IsMessageEncrypted(requestContext))
			{
				throw new ApplicationException("The request is not encrypted.");
			}

			// Use the SCT to sign and encrypt the response
			SoapContext responseContext = ResponseSoapContext.Current;
			responseContext.Security.Tokens.Add(sct);
			responseContext.Security.Elements.Add(new MessageSignature(sct));
			responseContext.Security.Elements.Add(new EncryptedData(sct));

			// Step 2: Create a new Quote object, but only populate it if signature is valid
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

		[WebMethod()]
		[SoapDocumentMethod(RequestNamespace="http://www.bluestonepartners.com/schemas/StockTrader/", ResponseNamespace="http://www.bluestonepartners.com/schemas/StockTrader/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Bare)]
		[return: XmlElement("Trade", Namespace = "http://www.bluestonepartners.com/schemas/StockTrader/")]
		public Trade PlaceTrade(string Account, string Symbol, int Shares, System.Double Price, TradeType tradeType)
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

		[WebMethod()]
		[SoapDocumentMethod(RequestNamespace="http://www.bluestonepartners.com/schemas/StockTrader/", ResponseNamespace="http://www.bluestonepartners.com/schemas/StockTrader/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Bare)]
		[return: XmlElement("Trade", Namespace = "http://www.bluestonepartners.com/schemas/StockTrader/")]
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
		
		[WebMethod()]
		[SoapDocumentMethod(RequestNamespace="http://www.bluestonepartners.com/schemas/StockTrader/", ResponseNamespace="http://www.bluestonepartners.com/schemas/StockTrader/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Bare)]
		[return: XmlElement("Trades", Namespace = "http://www.bluestonepartners.com/schemas/StockTrader/")]
		public Trades RequestAllTradesSummary(string Account)
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

		private SecurityToken GetSigningToken(SoapContext context)
		{
			foreach ( ISecurityElement element in context.Security.Elements )
			{
				if ( element is MessageSignature )
				{
					// The given context contains a Signature element.
					MessageSignature sig = element as MessageSignature;

					if ((sig.SignatureOptions & SignatureOptions.IncludeSoapBody) != 0)
					{
						// The SOAP Body is signed.
						return sig.SigningToken;
					}
				}
			}
			return null;
		}

		// Helper method that checks if the given SOAP context is encrypted.
		private bool IsMessageEncrypted(SoapContext context)
		{
			foreach (ISecurityElement element in context.Security.Elements)
			{
				if (element is EncryptedData)
				{
					EncryptedData encryptedData = element as EncryptedData;
					System.Xml.XmlElement targetElement = encryptedData.TargetElement;										
							
					if ( (targetElement.LocalName == Soap.ElementNames.Body) && (targetElement.NamespaceURI == Soap.NamespaceURI.get) && (SoapEnvelope.IsSoapEnvelope(targetElement.ParentNode)))
					{
						// The given context has the Body element Encrypted.
						return true;
					}
				}
			}
			return false;
		}

	}

	/// <summary>
	/// By implementing UsernameTokenManager we can verify the signature
	/// on messages received.
	/// </summary>
	/// <remarks>
	/// This class includes this demand to ensure that any untrusted
	/// assemblies cannot invoke this code. This helps mitigate
	/// brute-force discovery attacks.
	/// </remarks>
	[SecurityPermissionAttribute(SecurityAction.Demand, Flags=SecurityPermissionFlag.UnmanagedCode)]
	public class CustomUsernameTokenManager : UsernameTokenManager
	{
		/// <summary>
		/// Returns the password or password equivalent for the username provided.
		/// </summary>
		/// <param name="token">The username token</param>
		/// <returns>The password (or password equivalent) for the username</returns>
		protected override string AuthenticateToken( UsernameToken token )
		{
			// This method returns the password for the provided username
			// WSE will make the determination if they match
			byte[] password = System.Text.Encoding.UTF8.GetBytes( token.Username );
			Array.Reverse( password );
			return Convert.ToBase64String( password );

			// Note, in a production system you could retrieve the username from the token
			// and then use this to perform a database lookup of the system password.
			// Then return the password from AuthenticateToken().
			// WSE will raise a SOAP fault if this password does not match the one that generated the token.
			
			//			// This code returns an invalid password, which will generate a SOAP fault
			//			password = System.Text.Encoding.UTF8.GetBytes( "test" );
			//			return Convert.ToBase64String( password );
		}
	}
}