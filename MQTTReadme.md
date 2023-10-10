# MQTT
The server and the client are both implemented using the MQTTNet Nuget Package. The Server will relay all messages to clients, and the clients will only receive messages they subscribe to.

When working with this you would normally have a server somewhere (a server does not do anything, but relay messages). To "subscribe" to messages you would connect a client and listen for a certain topic. This is how you get data from different IoT devices.

[Introduction to MQTT](https://www.hivemq.com/mqtt/)
