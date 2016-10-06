
README for Chapter 9 Sample Solutions

This chapter includes 5 sample solutions:

1. StockTraderSoapReceiver.sln
2. StockTraderSoapSender.sln
3. StockTraderSoapMSMQService.sln
4. StockTraderSoapMSMQSender.sln
5. SOAPRouter.sln

Solutions #1 and #2 demonstrate asynchronous messaging using TCP. You will need to start
StockTraderSoapReceiver.sln in debug mode, so that it stays open in receiving mode.
Then separately start StockTraderSoapSender.sln to send a message to the receiver.

Solutions #3 and #4 demonstrate asynchronous messaging with MSMQ using TCP. You will need to start
StockTraderSoapMSMQService.sln in debug mode, so that it stays open in receiving mode.
Then separately start StockTraderSoapMSMQSender.sln to send a message to the receiver.

Solution #5 is a stand-alone solution that demonstrates SOAP message routing. This solution contains
three projects: SOAPSender.csproj, SOAPReceiver.csproj and SOAPRouter.csproj.
Before opening this solution file please run the CreateSampleVdir.vbs script to automatically create 
any required virtual directories. (You can later uninstall these virtual directories using the
DeleteSampleVdir.vbs script).

The sample solutions were built using the WSE v2.0 Toolkit.

Please refer to Chapter 9 for more information on the sample solution.

For updated source files, visit: http://www.bluestonepartners.com/soa