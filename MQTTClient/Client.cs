using MQTTnet;
using MQTTnet.Client;
using Protocols.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQTTClient
{
    public class Client
    {
        private string clientId;
        private MqttFactory mqttFactory;
        private IMqttClient client;
        public Client()
        {
            this.clientId = "C-" + Guid.NewGuid().ToString();
            mqttFactory = new MqttFactory();
        }
        public async Task Start(string listenToTopic)
        {
            var mqttFactory = new MqttFactory();

            this.client = mqttFactory.CreateMqttClient();

            // Use builder classes where possible in this project.
            var mqttClientOptions = new MqttClientOptionsBuilder().WithTcpServer("localhost", 1883).WithClientId(this.clientId).Build();

            // Setup message handling before connecting so that queued messages
            // are also handled properly. When there is no event handler attached all
            // received messages get lost.
            this.client.ApplicationMessageReceivedAsync += e =>
            {
                Console.WriteLine($"Received: {e.ApplicationMessage.Topic} => {e.ApplicationMessage.ConvertPayloadToString()}");

                return Task.CompletedTask;
            };

            // This will throw an exception if the server is not available.
            // The result from this message returns additional data which was sent 
            // from the server. Please refer to the MQTT protocol specification for details.
            var response = await this.client.ConnectAsync(mqttClientOptions, CancellationToken.None);
            var mqttSubscribeOptions = mqttFactory.CreateSubscribeOptionsBuilder()
            .WithTopicFilter(
                f =>
                {
                    f.WithTopic(listenToTopic);
                })
            .Build();
            await this.client.SubscribeAsync(mqttSubscribeOptions, CancellationToken.None);

            Console.WriteLine("The MQTT client is connected.");
            Console.WriteLine("ClientId: " + this.clientId);
        }

        public async Task SendMessage(string topic, string message)
        {
            Console.WriteLine($"Sending message: {topic} => {message}");
            var applicationMessage = new MqttApplicationMessageBuilder()
               .WithTopic(topic)
               .WithPayload(message)
            .Build();

            await this.client.PublishAsync(applicationMessage, CancellationToken.None);
        }
    }
}
