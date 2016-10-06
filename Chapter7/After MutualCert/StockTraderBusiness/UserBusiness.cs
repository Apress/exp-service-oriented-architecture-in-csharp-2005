using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace StockTraderBusiness
{
    public class UserBusiness
    {

        private static object mutex = new object();
        private static UserBusiness _instance;
        public Dictionary<string,string> users = new Dictionary<string,string>();

        private UserBusiness()
        {

            users.Add("admin", "adminpwd");
            users.Add("user", "userpwd");
            
        }

        public static UserBusiness GetInstance()
        {
            lock (mutex)
            {
                if (_instance == null)
                {
                    _instance = new UserBusiness();
                }
            }
            return _instance;
        }

        public string GetPassword(string userName)
        {
            return users[userName];

        }

     
    }
}
