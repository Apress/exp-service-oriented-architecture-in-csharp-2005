using System;
using System.Xml;

using Microsoft.Web.Services3.Security;
using Microsoft.Web.Services3.Security.Tokens;

namespace StockTraderSecure
{

    public class CustomUsernameTokenManager : UsernameTokenManager
    {

        public CustomUsernameTokenManager()
        {
        }

        public CustomUsernameTokenManager(XmlNodeList nodes)
            : base(nodes)
        {
        }

        protected override string AuthenticateToken(UsernameToken token)
        {

            // return the password, in this sample, the password is the same value
            // as the user name, but in upper case

            // In a production application, the password would be retrieved 
            // from an external storage, such as a SQL Server database or
            // a LDAP directory.

            return token.Username.ToUpper();

        }

    }
}

