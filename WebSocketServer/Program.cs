using Protocols.Common.Services;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseWebSockets(); //Configure to use websockets                     
app.Use(async (context, next) =>// Handle WebSocket requests
{
    if (context.WebSockets.IsWebSocketRequest)
    {
        using (WebSocket webSocket = await context.WebSockets.AcceptWebSocketAsync())
        {
            await HandleWebSocketConnection(context, webSocket);
        }
    }
    else
    {
        await next();
    }
});
app.UseHttpsRedirection();


app.MapGet("/news", () =>
{
    return NewsTickerService.GetAllNews();
})
.WithName("GetAllNews")
.WithOpenApi();

app.Run();


async Task HandleWebSocketConnection(HttpContext context, WebSocket webSocket)
{
    byte[] receiveBuffer = new byte[1024];

    // Create a timer to send news items every 3 seconds
    var timer = new Timer(async state =>
    {
        string newsItem = NewsTickerService.GetRandomNewsItem();
        if (webSocket.State != WebSocketState.Open)
        {
            return;
        }

        // Send the news item to the client
        byte[] responseBuffer = Encoding.UTF8.GetBytes(newsItem);
        await webSocket.SendAsync(new ArraySegment<byte>(responseBuffer), WebSocketMessageType.Text, true, CancellationToken.None);
    }, null, 0, 3000);

    while (webSocket.State == WebSocketState.Open)
    {
        WebSocketReceiveResult result = await webSocket.ReceiveAsync(new ArraySegment<byte>(receiveBuffer), CancellationToken.None);

        if (result.MessageType == WebSocketMessageType.Text)
        {
            string receivedMessage = Encoding.UTF8.GetString(receiveBuffer, 0, result.Count);
            Console.WriteLine($"Received message from client: {receivedMessage}");

            // Respond to the client
            string responseMessage = "BREAKING NEWS: " + receivedMessage; //appending text to the received message and send it back
            byte[] responseBuffer = Encoding.UTF8.GetBytes(responseMessage);
            await webSocket.SendAsync(new ArraySegment<byte>(responseBuffer), WebSocketMessageType.Text, true, CancellationToken.None);
        }
    }
}
