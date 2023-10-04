# SOAP Services
This solution is built on a SOAP Server and a single client. Generally speaking it is hard to create a SOAP server in .Net Core (WCF is a component in the .Net framework, not in .Net Core).

## SOAP Server
The SOAP Server is built on a "ASP.NET Core Web API" with the Nuget package `SOAPCore` installed. An alternative could be to use WCF services in .Net Framework (not .Net Core).

## SOAP Client
There are several solutions for a SOAP client. In its simplest form this is "just" XML being sent back and forward over an HTTP connection.
It is possible to use the `svcutil.exe` tool to generate the client proxy from the WSDL.
It is possible to use Postman as a client to post and retrieve data from a SOAP server. It is also possible to use the `Wizdler´ Chrome Browser plugin (go to the .asmx file and press the plugin)
