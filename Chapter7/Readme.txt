Chapter 7
---------

Please run the CreateSampleVdir.vbs script before opening the Kerberos sample solution. This script will create the virtual directory that is used to access the StockTraderSecure Web Service project.

NOTES:

- Make sure you restart IIS after making any changes to the machine.config file. Please refer to the section "Set Up the Environment" on page 150 to identify if you need to make changes to this file.

- The domain account that you use to run the ASP.NET process model needs to have access to the IIS metabase. Use the following command to give the proper permissions to the domain account.

	aspnet_regiis –ga <WindowsUserAccount>

	caution: You might need to restart IIS and reopen Visual Studio if you attempt to debug the application prior to giving the proper permissions to the domain account.






