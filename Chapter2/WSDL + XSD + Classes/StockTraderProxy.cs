﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.42
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Serialization;

// 
// This source code was auto-generated by wsdl, Version=2.0.50727.42.
// 


/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Web.Services.WebServiceBindingAttribute(Name="StockTrader3Soap", Namespace="http://www.bluestonepartners.com/schemas/StockTrader/")]
public partial class StockTrader3 : System.Web.Services.Protocols.SoapHttpClientProtocol {
    
    private System.Threading.SendOrPostCallback RequestQuoteOperationCompleted;
    
    /// <remarks/>
    public StockTrader3() {
        this.Url = "http://localhost/StockTrader/StockTrader3.asmx";
    }
    
    /// <remarks/>
    public event RequestQuoteCompletedEventHandler RequestQuoteCompleted;
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.bluestonepartners.com/schemas/StockTrader/RequestQuote", RequestNamespace="http://www.bluestonepartners.com/schemas/StockTrader/", ResponseNamespace="http://www.bluestonepartners.com/schemas/StockTrader/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlElementAttribute("Quote")]
    public Quote RequestQuote(string Symbol) {
        object[] results = this.Invoke("RequestQuote", new object[] {
                    Symbol});
        return ((Quote)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginRequestQuote(string Symbol, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("RequestQuote", new object[] {
                    Symbol}, callback, asyncState);
    }
    
    /// <remarks/>
    public Quote EndRequestQuote(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
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
    public new void CancelAsync(object userState) {
        base.CancelAsync(userState);
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
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
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
public delegate void RequestQuoteCompletedEventHandler(object sender, RequestQuoteCompletedEventArgs e);

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
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