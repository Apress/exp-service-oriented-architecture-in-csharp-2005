﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.42
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Xml.Serialization;

namespace StockTrader
{
    // 
    // This source code was auto-generated by xsd, Version=2.0.50727.42.
    // 

    public abstract class StockTraderStub : System.Web.Services.WebService
    {
        [return: XmlElement("Quote", Namespace = "http://www.bluestonepartners.com/schemas/StockTrader/")]
        public abstract Quote RequestQuote(string Symbol);

        [return: XmlElement("Trade", Namespace = "http://www.bluestonepartners.com/schemas/StockTrader/")]
        public abstract Trade PlaceTrade(string Account, string Symbol, int Shares, System.Double Price, TradeType tradeType);

        [return: XmlElement("Trade", Namespace = "http://www.bluestonepartners.com/schemas/StockTrader/")]
        public abstract Trade RequestTradeDetails(string Account, string TradeID);

        [return: XmlElement("Trades", Namespace = "http://www.bluestonepartners.com/schemas/StockTrader/")]
        public abstract Trades RequestAllTradesSummary(string Account);
    }


    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.bluestonepartners.com/Schemas/StockTrader/")]
    [System.Xml.Serialization.XmlRootAttribute("tradeType", Namespace = "http://www.bluestonepartners.com/Schemas/StockTrader/", IsNullable = false)]
    public enum TradeType
    {

        /// <remarks/>
        Bid,

        /// <remarks/>
        Ask,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.bluestonepartners.com/Schemas/StockTrader/")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.bluestonepartners.com/Schemas/StockTrader/", IsNullable = false)]
    public partial class Quote
    {

        private string symbolField;

        private string companyField;

        private string dateTimeField;

        private double highField;

        private double lowField;

        private double openField;

        private double lastField;

        private double changeField;

        private double percentChangeField;

        private double previous_CloseField;

        private double high_52_WeekField;

        private double low_52_WeekField;

        /// <remarks/>
        public string Symbol
        {
            get
            {
                return this.symbolField;
            }
            set
            {
                this.symbolField = value;
            }
        }

        /// <remarks/>
        public string Company
        {
            get
            {
                return this.companyField;
            }
            set
            {
                this.companyField = value;
            }
        }

        /// <remarks/>
        public string DateTime
        {
            get
            {
                return this.dateTimeField;
            }
            set
            {
                this.dateTimeField = value;
            }
        }

        /// <remarks/>
        public double High
        {
            get
            {
                return this.highField;
            }
            set
            {
                this.highField = value;
            }
        }

        /// <remarks/>
        public double Low
        {
            get
            {
                return this.lowField;
            }
            set
            {
                this.lowField = value;
            }
        }

        /// <remarks/>
        public double Open
        {
            get
            {
                return this.openField;
            }
            set
            {
                this.openField = value;
            }
        }

        /// <remarks/>
        public double Last
        {
            get
            {
                return this.lastField;
            }
            set
            {
                this.lastField = value;
            }
        }

        /// <remarks/>
        public double Change
        {
            get
            {
                return this.changeField;
            }
            set
            {
                this.changeField = value;
            }
        }

        /// <remarks/>
        public double PercentChange
        {
            get
            {
                return this.percentChangeField;
            }
            set
            {
                this.percentChangeField = value;
            }
        }

        /// <remarks/>
        public double Previous_Close
        {
            get
            {
                return this.previous_CloseField;
            }
            set
            {
                this.previous_CloseField = value;
            }
        }

        /// <remarks/>
        public double High_52_Week
        {
            get
            {
                return this.high_52_WeekField;
            }
            set
            {
                this.high_52_WeekField = value;
            }
        }

        /// <remarks/>
        public double Low_52_Week
        {
            get
            {
                return this.low_52_WeekField;
            }
            set
            {
                this.low_52_WeekField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.bluestonepartners.com/Schemas/StockTrader/")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.bluestonepartners.com/Schemas/StockTrader/", IsNullable = false)]
    public partial class Trades
    {

        private string accountField;

        private Trade[] bidsField;

        private Trade[] asksField;

        /// <remarks/>
        public string Account
        {
            get
            {
                return this.accountField;
            }
            set
            {
                this.accountField = value;
            }
        }

        /// <remarks/>
        public Trade[] Bids
        {
            get
            {
                return this.bidsField;
            }
            set
            {
                this.bidsField = value;
            }
        }

        /// <remarks/>
        public Trade[] Asks
        {
            get
            {
                return this.asksField;
            }
            set
            {
                this.asksField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.bluestonepartners.com/Schemas/StockTrader/")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.bluestonepartners.com/Schemas/StockTrader/", IsNullable = false)]
    public partial class Trade
    {

        private string tradeIDField;

        private string symbolField;

        private double priceField;

        private int sharesField;

        private TradeType tradeTypeField;

        private TradeStatus tradeStatusField;

        private string orderDateTimeField;

        private string lastActivityDateTimeField;

        /// <remarks/>
        public string TradeID
        {
            get
            {
                return this.tradeIDField;
            }
            set
            {
                this.tradeIDField = value;
            }
        }

        /// <remarks/>
        public string Symbol
        {
            get
            {
                return this.symbolField;
            }
            set
            {
                this.symbolField = value;
            }
        }

        /// <remarks/>
        public double Price
        {
            get
            {
                return this.priceField;
            }
            set
            {
                this.priceField = value;
            }
        }

        /// <remarks/>
        public int Shares
        {
            get
            {
                return this.sharesField;
            }
            set
            {
                this.sharesField = value;
            }
        }

        /// <remarks/>
        public TradeType tradeType
        {
            get
            {
                return this.tradeTypeField;
            }
            set
            {
                this.tradeTypeField = value;
            }
        }

        /// <remarks/>
        public TradeStatus tradeStatus
        {
            get
            {
                return this.tradeStatusField;
            }
            set
            {
                this.tradeStatusField = value;
            }
        }

        /// <remarks/>
        public string OrderDateTime
        {
            get
            {
                return this.orderDateTimeField;
            }
            set
            {
                this.orderDateTimeField = value;
            }
        }

        /// <remarks/>
        public string LastActivityDateTime
        {
            get
            {
                return this.lastActivityDateTimeField;
            }
            set
            {
                this.lastActivityDateTimeField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.bluestonepartners.com/Schemas/StockTrader/")]
    public enum TradeStatus
    {

        /// <remarks/>
        Ordered,

        /// <remarks/>
        Filled,

        /// <remarks/>
        Cancelled,

        /// <remarks/>
        Unfilled,
    }
}
