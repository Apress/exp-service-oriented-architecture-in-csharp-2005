﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.42
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 2.0.50727.42.
// 
#pragma warning disable 1591

namespace StockTraderClient.StockTraderProxy {
    using System.Diagnostics;
    using System.Web.Services;
    using System.ComponentModel;
    using System.Web.Services.Protocols;
    using System;
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="StockTraderSoap", Namespace="http://www.bluestonepartners.com/schemas/StockTrader/")]
    public partial class StockTraderWse : Microsoft.Web.Services3.WebServicesClientProtocol {
        
        private System.Threading.SendOrPostCallback RequestQuoteOperationCompleted;
        
        private System.Threading.SendOrPostCallback PlaceTradeOperationCompleted;
        
        private System.Threading.SendOrPostCallback RequestTradeDetailsOperationCompleted;
        
        private System.Threading.SendOrPostCallback RequestAllTradesSummaryOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public StockTraderWse() {
            this.Url = global::StockTraderClient.Properties.Settings.Default.StockTraderClient_StockTraderProxy_StockTrader;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event RequestQuoteCompletedEventHandler RequestQuoteCompleted;
        
        /// <remarks/>
        public event PlaceTradeCompletedEventHandler PlaceTradeCompleted;
        
        /// <remarks/>
        public event RequestTradeDetailsCompletedEventHandler RequestTradeDetailsCompleted;
        
        /// <remarks/>
        public event RequestAllTradesSummaryCompletedEventHandler RequestAllTradesSummaryCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.bluestonepartners.com/schemas/StockTrader/RequestQuote", RequestNamespace="http://www.bluestonepartners.com/schemas/StockTrader/", ResponseNamespace="http://www.bluestonepartners.com/schemas/StockTrader/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("Quote")]
        public Quote RequestQuote(string Symbol) {
            object[] results = this.Invoke("RequestQuote", new object[] {
                        Symbol});
            return ((Quote)(results[0]));
        }
        
        /// <remarks/>
        public void RequestQuoteAsync(string Symbol) {
            this.RequestQuoteAsync(Symbol, null);
        }
        
        /// <remarks/>
        public void RequestQuoteAsync(string Symbol, object userState) {
            if ((this.RequestQuoteOperationCompleted == null)) {
                this.RequestQuoteOperationCompleted = new System.Threading.SendOrPostCallback(this.OnRequestQuoteOperationCompleted);
            }
            this.InvokeAsync("RequestQuote", new object[] {
                        Symbol}, this.RequestQuoteOperationCompleted, userState);
        }
        
        private void OnRequestQuoteOperationCompleted(object arg) {
            if ((this.RequestQuoteCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.RequestQuoteCompleted(this, new RequestQuoteCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.bluestonepartners.com/schemas/StockTrader/PlaceTrade", RequestNamespace="http://www.bluestonepartners.com/schemas/StockTrader/", ResponseNamespace="http://www.bluestonepartners.com/schemas/StockTrader/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("Trade")]
        public Trade PlaceTrade(string Account, string Symbol, int Shares, double Price, TradeType tradeType) {
            object[] results = this.Invoke("PlaceTrade", new object[] {
                        Account,
                        Symbol,
                        Shares,
                        Price,
                        tradeType});
            return ((Trade)(results[0]));
        }
        
        /// <remarks/>
        public void PlaceTradeAsync(string Account, string Symbol, int Shares, double Price, TradeType tradeType) {
            this.PlaceTradeAsync(Account, Symbol, Shares, Price, tradeType, null);
        }
        
        /// <remarks/>
        public void PlaceTradeAsync(string Account, string Symbol, int Shares, double Price, TradeType tradeType, object userState) {
            if ((this.PlaceTradeOperationCompleted == null)) {
                this.PlaceTradeOperationCompleted = new System.Threading.SendOrPostCallback(this.OnPlaceTradeOperationCompleted);
            }
            this.InvokeAsync("PlaceTrade", new object[] {
                        Account,
                        Symbol,
                        Shares,
                        Price,
                        tradeType}, this.PlaceTradeOperationCompleted, userState);
        }
        
        private void OnPlaceTradeOperationCompleted(object arg) {
            if ((this.PlaceTradeCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.PlaceTradeCompleted(this, new PlaceTradeCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.bluestonepartners.com/schemas/StockTrader/RequestTradeDetails", RequestNamespace="http://www.bluestonepartners.com/schemas/StockTrader/", ResponseNamespace="http://www.bluestonepartners.com/schemas/StockTrader/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("Trade")]
        public Trade RequestTradeDetails(string Account, string TradeID) {
            object[] results = this.Invoke("RequestTradeDetails", new object[] {
                        Account,
                        TradeID});
            return ((Trade)(results[0]));
        }
        
        /// <remarks/>
        public void RequestTradeDetailsAsync(string Account, string TradeID) {
            this.RequestTradeDetailsAsync(Account, TradeID, null);
        }
        
        /// <remarks/>
        public void RequestTradeDetailsAsync(string Account, string TradeID, object userState) {
            if ((this.RequestTradeDetailsOperationCompleted == null)) {
                this.RequestTradeDetailsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnRequestTradeDetailsOperationCompleted);
            }
            this.InvokeAsync("RequestTradeDetails", new object[] {
                        Account,
                        TradeID}, this.RequestTradeDetailsOperationCompleted, userState);
        }
        
        private void OnRequestTradeDetailsOperationCompleted(object arg) {
            if ((this.RequestTradeDetailsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.RequestTradeDetailsCompleted(this, new RequestTradeDetailsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.bluestonepartners.com/schemas/StockTrader/RequestAllTradesSummary", RequestNamespace="http://www.bluestonepartners.com/schemas/StockTrader/", ResponseNamespace="http://www.bluestonepartners.com/schemas/StockTrader/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("Trades")]
        public Trades RequestAllTradesSummary(string Account) {
            object[] results = this.Invoke("RequestAllTradesSummary", new object[] {
                        Account});
            return ((Trades)(results[0]));
        }
        
        /// <remarks/>
        public void RequestAllTradesSummaryAsync(string Account) {
            this.RequestAllTradesSummaryAsync(Account, null);
        }
        
        /// <remarks/>
        public void RequestAllTradesSummaryAsync(string Account, object userState) {
            if ((this.RequestAllTradesSummaryOperationCompleted == null)) {
                this.RequestAllTradesSummaryOperationCompleted = new System.Threading.SendOrPostCallback(this.OnRequestAllTradesSummaryOperationCompleted);
            }
            this.InvokeAsync("RequestAllTradesSummary", new object[] {
                        Account}, this.RequestAllTradesSummaryOperationCompleted, userState);
        }
        
        private void OnRequestAllTradesSummaryOperationCompleted(object arg) {
            if ((this.RequestAllTradesSummaryCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.RequestAllTradesSummaryCompleted(this, new RequestAllTradesSummaryCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="StockTraderSoap", Namespace="http://www.bluestonepartners.com/schemas/StockTrader/")]
    public partial class StockTrader : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback RequestQuoteOperationCompleted;
        
        private System.Threading.SendOrPostCallback PlaceTradeOperationCompleted;
        
        private System.Threading.SendOrPostCallback RequestTradeDetailsOperationCompleted;
        
        private System.Threading.SendOrPostCallback RequestAllTradesSummaryOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public StockTrader() {
            this.Url = global::StockTraderClient.Properties.Settings.Default.StockTraderClient_StockTraderProxy_StockTrader;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event RequestQuoteCompletedEventHandler RequestQuoteCompleted;
        
        /// <remarks/>
        public event PlaceTradeCompletedEventHandler PlaceTradeCompleted;
        
        /// <remarks/>
        public event RequestTradeDetailsCompletedEventHandler RequestTradeDetailsCompleted;
        
        /// <remarks/>
        public event RequestAllTradesSummaryCompletedEventHandler RequestAllTradesSummaryCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.bluestonepartners.com/schemas/StockTrader/RequestQuote", RequestNamespace="http://www.bluestonepartners.com/schemas/StockTrader/", ResponseNamespace="http://www.bluestonepartners.com/schemas/StockTrader/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("Quote")]
        public Quote RequestQuote(string Symbol) {
            object[] results = this.Invoke("RequestQuote", new object[] {
                        Symbol});
            return ((Quote)(results[0]));
        }
        
        /// <remarks/>
        public void RequestQuoteAsync(string Symbol) {
            this.RequestQuoteAsync(Symbol, null);
        }
        
        /// <remarks/>
        public void RequestQuoteAsync(string Symbol, object userState) {
            if ((this.RequestQuoteOperationCompleted == null)) {
                this.RequestQuoteOperationCompleted = new System.Threading.SendOrPostCallback(this.OnRequestQuoteOperationCompleted);
            }
            this.InvokeAsync("RequestQuote", new object[] {
                        Symbol}, this.RequestQuoteOperationCompleted, userState);
        }
        
        private void OnRequestQuoteOperationCompleted(object arg) {
            if ((this.RequestQuoteCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.RequestQuoteCompleted(this, new RequestQuoteCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.bluestonepartners.com/schemas/StockTrader/PlaceTrade", RequestNamespace="http://www.bluestonepartners.com/schemas/StockTrader/", ResponseNamespace="http://www.bluestonepartners.com/schemas/StockTrader/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("Trade")]
        public Trade PlaceTrade(string Account, string Symbol, int Shares, double Price, TradeType tradeType) {
            object[] results = this.Invoke("PlaceTrade", new object[] {
                        Account,
                        Symbol,
                        Shares,
                        Price,
                        tradeType});
            return ((Trade)(results[0]));
        }
        
        /// <remarks/>
        public void PlaceTradeAsync(string Account, string Symbol, int Shares, double Price, TradeType tradeType) {
            this.PlaceTradeAsync(Account, Symbol, Shares, Price, tradeType, null);
        }
        
        /// <remarks/>
        public void PlaceTradeAsync(string Account, string Symbol, int Shares, double Price, TradeType tradeType, object userState) {
            if ((this.PlaceTradeOperationCompleted == null)) {
                this.PlaceTradeOperationCompleted = new System.Threading.SendOrPostCallback(this.OnPlaceTradeOperationCompleted);
            }
            this.InvokeAsync("PlaceTrade", new object[] {
                        Account,
                        Symbol,
                        Shares,
                        Price,
                        tradeType}, this.PlaceTradeOperationCompleted, userState);
        }
        
        private void OnPlaceTradeOperationCompleted(object arg) {
            if ((this.PlaceTradeCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.PlaceTradeCompleted(this, new PlaceTradeCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.bluestonepartners.com/schemas/StockTrader/RequestTradeDetails", RequestNamespace="http://www.bluestonepartners.com/schemas/StockTrader/", ResponseNamespace="http://www.bluestonepartners.com/schemas/StockTrader/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("Trade")]
        public Trade RequestTradeDetails(string Account, string TradeID) {
            object[] results = this.Invoke("RequestTradeDetails", new object[] {
                        Account,
                        TradeID});
            return ((Trade)(results[0]));
        }
        
        /// <remarks/>
        public void RequestTradeDetailsAsync(string Account, string TradeID) {
            this.RequestTradeDetailsAsync(Account, TradeID, null);
        }
        
        /// <remarks/>
        public void RequestTradeDetailsAsync(string Account, string TradeID, object userState) {
            if ((this.RequestTradeDetailsOperationCompleted == null)) {
                this.RequestTradeDetailsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnRequestTradeDetailsOperationCompleted);
            }
            this.InvokeAsync("RequestTradeDetails", new object[] {
                        Account,
                        TradeID}, this.RequestTradeDetailsOperationCompleted, userState);
        }
        
        private void OnRequestTradeDetailsOperationCompleted(object arg) {
            if ((this.RequestTradeDetailsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.RequestTradeDetailsCompleted(this, new RequestTradeDetailsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.bluestonepartners.com/schemas/StockTrader/RequestAllTradesSummary", RequestNamespace="http://www.bluestonepartners.com/schemas/StockTrader/", ResponseNamespace="http://www.bluestonepartners.com/schemas/StockTrader/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("Trades")]
        public Trades RequestAllTradesSummary(string Account) {
            object[] results = this.Invoke("RequestAllTradesSummary", new object[] {
                        Account});
            return ((Trades)(results[0]));
        }
        
        /// <remarks/>
        public void RequestAllTradesSummaryAsync(string Account) {
            this.RequestAllTradesSummaryAsync(Account, null);
        }
        
        /// <remarks/>
        public void RequestAllTradesSummaryAsync(string Account, object userState) {
            if ((this.RequestAllTradesSummaryOperationCompleted == null)) {
                this.RequestAllTradesSummaryOperationCompleted = new System.Threading.SendOrPostCallback(this.OnRequestAllTradesSummaryOperationCompleted);
            }
            this.InvokeAsync("RequestAllTradesSummary", new object[] {
                        Account}, this.RequestAllTradesSummaryOperationCompleted, userState);
        }
        
        private void OnRequestAllTradesSummaryOperationCompleted(object arg) {
            if ((this.RequestAllTradesSummaryCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.RequestAllTradesSummaryCompleted(this, new RequestAllTradesSummaryCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.bluestonepartners.com/Schemas/StockTrader/")]
    public partial class Quote {
        
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
        public string Symbol {
            get {
                return this.symbolField;
            }
            set {
                this.symbolField = value;
            }
        }
        
        /// <remarks/>
        public string Company {
            get {
                return this.companyField;
            }
            set {
                this.companyField = value;
            }
        }
        
        /// <remarks/>
        public string DateTime {
            get {
                return this.dateTimeField;
            }
            set {
                this.dateTimeField = value;
            }
        }
        
        /// <remarks/>
        public double High {
            get {
                return this.highField;
            }
            set {
                this.highField = value;
            }
        }
        
        /// <remarks/>
        public double Low {
            get {
                return this.lowField;
            }
            set {
                this.lowField = value;
            }
        }
        
        /// <remarks/>
        public double Open {
            get {
                return this.openField;
            }
            set {
                this.openField = value;
            }
        }
        
        /// <remarks/>
        public double Last {
            get {
                return this.lastField;
            }
            set {
                this.lastField = value;
            }
        }
        
        /// <remarks/>
        public double Change {
            get {
                return this.changeField;
            }
            set {
                this.changeField = value;
            }
        }
        
        /// <remarks/>
        public double PercentChange {
            get {
                return this.percentChangeField;
            }
            set {
                this.percentChangeField = value;
            }
        }
        
        /// <remarks/>
        public double Previous_Close {
            get {
                return this.previous_CloseField;
            }
            set {
                this.previous_CloseField = value;
            }
        }
        
        /// <remarks/>
        public double High_52_Week {
            get {
                return this.high_52_WeekField;
            }
            set {
                this.high_52_WeekField = value;
            }
        }
        
        /// <remarks/>
        public double Low_52_Week {
            get {
                return this.low_52_WeekField;
            }
            set {
                this.low_52_WeekField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.bluestonepartners.com/Schemas/StockTrader/")]
    public partial class Trades {
        
        private string accountField;
        
        private Trade[] bidsField;
        
        private Trade[] asksField;
        
        /// <remarks/>
        public string Account {
            get {
                return this.accountField;
            }
            set {
                this.accountField = value;
            }
        }
        
        /// <remarks/>
        public Trade[] Bids {
            get {
                return this.bidsField;
            }
            set {
                this.bidsField = value;
            }
        }
        
        /// <remarks/>
        public Trade[] Asks {
            get {
                return this.asksField;
            }
            set {
                this.asksField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.bluestonepartners.com/Schemas/StockTrader/")]
    public partial class Trade {
        
        private string tradeIDField;
        
        private string symbolField;
        
        private double priceField;
        
        private int sharesField;
        
        private TradeType tradeTypeField;
        
        private TradeStatus tradeStatusField;
        
        private string orderDateTimeField;
        
        private string lastActivityDateTimeField;
        
        /// <remarks/>
        public string TradeID {
            get {
                return this.tradeIDField;
            }
            set {
                this.tradeIDField = value;
            }
        }
        
        /// <remarks/>
        public string Symbol {
            get {
                return this.symbolField;
            }
            set {
                this.symbolField = value;
            }
        }
        
        /// <remarks/>
        public double Price {
            get {
                return this.priceField;
            }
            set {
                this.priceField = value;
            }
        }
        
        /// <remarks/>
        public int Shares {
            get {
                return this.sharesField;
            }
            set {
                this.sharesField = value;
            }
        }
        
        /// <remarks/>
        public TradeType tradeType {
            get {
                return this.tradeTypeField;
            }
            set {
                this.tradeTypeField = value;
            }
        }
        
        /// <remarks/>
        public TradeStatus tradeStatus {
            get {
                return this.tradeStatusField;
            }
            set {
                this.tradeStatusField = value;
            }
        }
        
        /// <remarks/>
        public string OrderDateTime {
            get {
                return this.orderDateTimeField;
            }
            set {
                this.orderDateTimeField = value;
            }
        }
        
        /// <remarks/>
        public string LastActivityDateTime {
            get {
                return this.lastActivityDateTimeField;
            }
            set {
                this.lastActivityDateTimeField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.bluestonepartners.com/Schemas/StockTrader/")]
    public enum TradeType {
        
        /// <remarks/>
        Bid,
        
        /// <remarks/>
        Ask,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.bluestonepartners.com/Schemas/StockTrader/")]
    public enum TradeStatus {
        
        /// <remarks/>
        Ordered,
        
        /// <remarks/>
        Filled,
        
        /// <remarks/>
        Cancelled,
        
        /// <remarks/>
        Unfilled,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42")]
    public delegate void RequestQuoteCompletedEventHandler(object sender, RequestQuoteCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class RequestQuoteCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal RequestQuoteCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Quote Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Quote)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42")]
    public delegate void PlaceTradeCompletedEventHandler(object sender, PlaceTradeCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class PlaceTradeCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal PlaceTradeCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Trade Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Trade)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42")]
    public delegate void RequestTradeDetailsCompletedEventHandler(object sender, RequestTradeDetailsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class RequestTradeDetailsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal RequestTradeDetailsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Trade Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Trade)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42")]
    public delegate void RequestAllTradesSummaryCompletedEventHandler(object sender, RequestAllTradesSummaryCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class RequestAllTradesSummaryCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal RequestAllTradesSummaryCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Trades Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Trades)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591