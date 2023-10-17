// See https://aka.ms/new-console-template for more information
using Grpc.Net.Client;
using GRPCServer;

Console.WriteLine("gRPC Client");
using var channel = GrpcChannel.ForAddress("https://localhost:7151");
//greeter client
var client = new GreeterGrpc.GreeterGrpcClient(channel);
var reply = await client.SayHelloAsync(new HelloRequest { Name = "GreeterClient" });
Console.WriteLine("Greeting: " + reply.Message);
//customer client
var customerClient = new CustomersGrpc.CustomersGrpcClient(channel);
var customerReply = customerClient.GetCustomer(new CustomerRequest() { Id = 1 });
Console.WriteLine($"Customer: Id: {customerReply.Id}, Email: {customerReply.Email} Name: {customerReply.Name}");
Console.WriteLine("Press any key to exit...");
Console.ReadKey();
