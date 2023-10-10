using MQTTnet.Server;
using MQTTnet;
using MQTTnet.Implementations;
using Protocols.Common.Utilities;

namespace MQTTServer
{
    public class Server
    {
        private MqttServer server;
        private MqttFactory mqttFactory;
        private MqttServerOptions options;
        public Server()
        {
            mqttFactory = new MqttFactory();
            options = new MqttServerOptionsBuilder().WithDefaultEndpoint().Build();
            server = mqttFactory.CreateMqttServer(options);
        }

        public async Task Start()
        {
            server.ClientConnectedAsync += MqttServer_ClientConnectedAsync;
            server.ClientDisconnectedAsync += MqttServer_ClientDisconnectedAsync;               
            await server.StartAsync();            
            Console.WriteLine($"Running on port: {options.DefaultEndpointOptions.Port}");
            Console.WriteLine("Press Enter to exit.");
            Console.ReadLine();

            // Stop and dispose the MQTT server if it is no longer needed!
            await server.StopAsync();

        }

        private async Task MqttServer_ClientDisconnectedAsync(ClientDisconnectedEventArgs arg)
        {
            await Task.Run(() => Console.WriteLine($"Client disconnected: {arg.ClientId}"));

        }

        private async Task MqttServer_ClientConnectedAsync(ClientConnectedEventArgs arg)
        {
            await Task.Run(() => Console.WriteLine($"Client connected: {arg.ClientId}"));            
        }
    }
}
