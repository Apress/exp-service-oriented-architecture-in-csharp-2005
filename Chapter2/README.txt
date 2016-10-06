
README for WSDL.EXE and StockTrader.wsdl and StockTrader.xsd

There are two folders:

1. Full WSDL

The full WSDL document for the StockTrader.asmx Web service.

2. WSDL + XSD + Classes

A partial WSDL file with the RequestQuote method only, for clarity.

You must have the XSD file in the same folder as the WSDL file
when running the WSDL.EXE utility. The WSDL file is provided in
this format for illustration purposes only.

To generate a proxy file from StockTrader.wsdl, type 
the following at the command prompt:

wsdl /o:StockTraderProxy.cs StockTrader.wsdl StockTrader.xsd


To generate a proxy file from StockTrader.wsdl, type
the following at the command prompt:

wsdl /server /o:StockTraderStub.cs StockTrader.wsdl StockTrader.xsd