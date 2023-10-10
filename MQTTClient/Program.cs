// See https://aka.ms/new-console-template for more information
using MQTTClient;

Console.WriteLine("MQTT Client");
Console.WriteLine("------------");
Client client = new Client();
await client.Start("smokealarm/heartbeat"); //listen to the topic. Normally the same client would not publish and listen to the same topic
for (int i = 0; i < 100; i++)
{
    //simulating 4 heartbeats ber second.
    await client.SendMessage("smokealarm/heartbeat", DateTime.Now.ToString());
    System.Threading.Thread.Sleep(250);
}
Console.WriteLine("-----------\nPress <enter> to exit.");
Console.ReadLine();
