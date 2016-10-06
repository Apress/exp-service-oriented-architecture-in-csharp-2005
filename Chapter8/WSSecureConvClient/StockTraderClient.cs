using System;
using System.Text;
using System.Configuration;
using Microsoft.Web.Services3;
using Microsoft.Web.Services3.Security;
using Microsoft.Web.Services3.Security.Tokens;
using Microsoft.Web.Services3.Security.X509;

namespace WSSecureConvClient
{
	/// <summary>
	/// Summary description for StockTraderClient.
	/// </summary>
	public class StockTraderClient
	{
		private string SCTID = "";

		[STAThread]
		static void Main(string[] args)
		{
			
			StockTraderClient client = null;

			try
			{
				// Create an instance of the StockTrader client, which initiates a secure conversation
				client = new StockTraderClient();
				
				// Create an instance of the StockTrader Web service proxy
				StockTraderServiceWse serviceProxy = new StockTraderServiceWse();
//				SoapContext requestContext = serviceProxy.RequestSoapContext;

//				// Create a security token to use as the base for the security context token
//				// The security context token (SCT) will be issued later by the security token service (STS)
//				SecurityToken token = client.GetSTSRequestSigningToken();
//
//				// Create a SecurityContextTokenServiceClient (STSClient) that will get the SecurityContextToken
//				string secureConvEndpoint = ConfigurationSettings.AppSettings["tokenIssuer"];
//				SecurityContextTokenServiceClient STSClient = new SecurityContextTokenServiceClient(new Uri( secureConvEndpoint ));
//				
//				// Retrieve the server certificate, to include in the signed request to the security token service (STS)
//				SecurityToken issuerToken = client.GetServerToken();
//
//				// Request the security context token, use the client's signing token as the base
//				SecurityContextToken sct;
//				sct = STSClient.IssueSecurityContextTokenAuthenticated(token, issuerToken);

				// Request the security context token
				SecurityContextToken sct = client.RequestSecurityContextToken(serviceProxy, client);

//				// Use the security context token to sign and encrypt a request to the Web service
//				SoapContext requestContext = serviceProxy.RequestSoapContext;
//				requestContext.Security.Tokens.Add( sct );
//				requestContext.Security.Elements.Add( new MessageSignature( sct ) );
//				requestContext.Security.Elements.Add( new EncryptedData( sct ) );
			
				// Assign the security context token to the SOAP request envelope
				client.AssignSecurityContextToken(serviceProxy, sct);

				// Request stock quotes
				client.RequestSecureStockQuote(serviceProxy, sct, "MSFT");
				client.RequestSecureStockQuote(serviceProxy, sct, "INTC");

			}
			catch (Exception e)
			{
				StringBuilder sb = new StringBuilder();
				if (e is System.Web.Services.Protocols.SoapException)
				{
					System.Web.Services.Protocols.SoapException se = e as System.Web.Services.Protocols.SoapException;
					sb.Append("SOAP-Fault code: " + se.Code.ToString());
					sb.Append("\n");
				}
				if (e != null)
				{
					sb.Append(e.ToString());
				}
				Console.WriteLine("*** Exception Raised ***");
				Console.WriteLine(sb.ToString());
				Console.WriteLine("************************");  
			}

			Console.WriteLine( "" );
			Console.WriteLine("Press [Enter] to continue...");
			Console.ReadLine();
		}

		private void AssignSecurityContextToken(StockTraderServiceWse serviceProxy, SecurityContextToken sct)
		{
			// Use the security context token to sign and encrypt a request to the Web service
			SoapContext requestContext = serviceProxy.RequestSoapContext;
			requestContext.Security.Tokens.Add( sct );
			requestContext.Security.Elements.Add( new MessageSignature( sct ) );
			requestContext.Security.Elements.Add( new EncryptedData( sct ) );
		}

		private SecurityContextToken RequestSecurityContextToken(StockTraderServiceWse serviceProxy, StockTraderClient client)
		{
			// Purpose: Return a security context token
			// Note: This function looks for a valid token in the global cache before automatically requesting a new one
			SecurityContextToken sct = null;
			try
			{
				// Look for a specific security token in the global cache, before requesting a new one
				if (client.SCTID.Length > 0 && PolicyEnforcementSecurityTokenCache.GlobalCache.Count > 0)
				{
					sct = RetrieveSecurityContextTokenFromGlobalCache(client.SCTID);
				}

				// Request a new security context token if one was not available from the global cache
				if (sct == null)
				{

					// Create a security token to use as the base for the security context token
					// The security context token (SCT) will be issued later by the security token service (STS)
					SecurityToken token = client.GetSTSRequestSigningToken();

					// Create a SecurityContextTokenServiceClient (STSClient) that will get the SecurityContextToken
					string secureConvEndpoint = ConfigurationManager.AppSettings["tokenIssuer"];
					SecurityContextTokenServiceClient STSClient = new SecurityContextTokenServiceClient(new Uri( secureConvEndpoint ));
					
					// Retrieve the server certificate, to include in the signed request to the security token service (STS)
					SecurityToken issuerToken = client.GetServerToken();

					// Request the security context token, use the client's signing token as the base
					sct = STSClient.IssueSecurityContextTokenAuthenticated(token, issuerToken);
				
					// Cache the security context token in the global cache for future requests
					// You must cache this token if you will be making multiple distinct requests
					// Otherwise, you will continue to generate new security context tokens
					PolicyEnforcementSecurityTokenCache.GlobalCache.Add(sct);

					// Cache the security context token ID for future retrieval
					client.SCTID = sct.Id;

				}

			}
			catch (Exception ex)
			{
				throw ex;
			}
			return sct;
		}

		private SecurityContextToken RetrieveSecurityContextTokenFromGlobalCache(string SCTID)
		{
			// Purpose: Retrieve a security context token from the global cache
			SecurityContextToken sct = null;
			try
			{
				// Loop through the collection of security context tokens
				System.Collections.IEnumerator enmTokens = PolicyEnforcementSecurityTokenCache.GlobalCache.GetEnumerator();
				SecurityContextToken token;

				while (enmTokens.MoveNext())
				{
					token = (SecurityContextToken)enmTokens.Current;
					if (token.Id == SCTID)
					{
						sct = token;
						break;
					}
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return sct;
		}

		private SecurityToken GetSTSRequestSigningToken()
		{
			// Create a security token to sign the request for the security token service (STS)
			SecurityToken token = null;
			try
			{
				string username      = Environment.UserName;
				byte[] passwordBytes = System.Text.Encoding.UTF8.GetBytes( username );
				Array.Reverse( passwordBytes );
				string passwordEquivalent = Convert.ToBase64String( passwordBytes );
				token = new UsernameToken( username, passwordEquivalent, PasswordOption.SendHashed );
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return token;
		}

		private X509SecurityToken GetServerToken()
		{
			// Purpose: Retrieve the server certificate from the client's CurrentUserStore
			X509SecurityToken token = null;
			string ServerBase64KeyId = "bBwPfItvKp3b6TNDq+14qs58VJQ=";

			// Open the CurrentUser Certificate Store
			X509CertificateStore store;
			store = X509CertificateStore.CurrentUserStore( X509CertificateStore.MyStore );
			if( !store.OpenRead() ) return null;
            
			// Place the key ID of the certificate in a byte array
			// This KeyID represents the Wse2Quickstart certificate included with the WSE 2.0 Quickstart samples
			X509CertificateCollection certs = store.FindCertificateByKeyIdentifier( Convert.FromBase64String( ServerBase64KeyId ) );

			if (certs.Count > 0)
			{
				// Get the first certificate in the collection
				token = new X509SecurityToken( ((X509Certificate) certs[0]) );
			}        

			return token;
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

		private bool IsMessageEncrypted(SoapContext context)
		{
			foreach (ISecurityElement element in context.Security.Elements)
			{
				if (element is EncryptedData)
				{
					EncryptedData encryptedData = element as EncryptedData;
					System.Xml.XmlElement targetElement = encryptedData.TargetElement;										
							
					if ( (targetElement.LocalName == Soap.ElementNames.Body) && (targetElement.NamespaceURI == Soap.NamespaceURI) && (SoapEnvelope.IsSoapEnvelope(targetElement.ParentNode)))
					{
						// The given context has the Body element Encrypted.
						return true;
					}
				}
			}
			return false;
		}

		private void RequestSecureStockQuote(StockTraderServiceWse serviceProxy, SecurityContextToken sct, string Symbol)
		{			
			// Call the Web service RequestQuote() method with the specified stock symbol
			Console.WriteLine("Calling {0}", serviceProxy.Url);
			Quote strQuote = serviceProxy.RequestQuote(Symbol);

			// Examine the Web service response to ensure that it is signed and encrypted
			// using the security context token that we originally used
			if ((GetSigningToken(serviceProxy.ResponseSoapContext) == null) ||
				(!IsMessageEncrypted(serviceProxy.ResponseSoapContext)))
			{
				throw new ApplicationException("The response was not signed and encrypted.");
			}

			// Display the results of the successful Web service request
			Console.WriteLine("Web Service call successful. Result:");
			Console.WriteLine( " " );
			Console.WriteLine( "Symbol: " + strQuote.Symbol );
			Console.WriteLine( "Price:  " + strQuote.Last );
			Console.WriteLine( "Change: " + strQuote.PercentChange + "%");
			Console.WriteLine( " " );
		}

	}
}
