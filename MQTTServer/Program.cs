// See https://aka.ms/new-console-template for more information
using MQTTServer;

Console.WriteLine("MQTT Server");
Server server = new Server();
await server.Start();
Console.WriteLine("Press <enter> to close client");
Console.ReadLine();
