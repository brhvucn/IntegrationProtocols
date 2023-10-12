using Newtonsoft.Json;
using SOAPServer.Model;
using System.Text;

Console.WriteLine("Webhook Sender");
Console.WriteLine("--------------");
//create the customer to send
var customer = new Customer(1)
{    
    Name = "Nordic Welding",
    Address = "Sofiendalsvej 58",
    City = "Aalborg",
    Country = "Denmark",
    Email = "info@nordicwelding.dk",
    PostalCode = "9100",
    Region = "Aalborg SV"
};
//the endpoint for the webhook - please note that pipedream.com is a popular too to use as a recipient for webhooks to inspect them

string endpoint = "WRITE YOUR OWN HTTP ENDPOINT HERE";
//create a http client and send the webhook
using (var httpClient = new HttpClient())
{
    try
    {
        // Serialize the customer object to JSON
        string json = JsonConvert.SerializeObject(customer);

        // Create a StringContent object with the JSON data
        StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

        // Send a POST request to the webhook endpoint with the JSON data
        HttpResponseMessage response = await httpClient.PostAsync(endpoint, content); // Provide the full endpoint URL if not set in the constructor

        // Check if the request was successful
        if (response.IsSuccessStatusCode)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Webhook sent successfully.");
            Console.WriteLine("Response: " + response.StatusCode);
            Console.ResetColor();
        }
        else
        {
            // Handle the error response, e.g., log the error or throw an exception
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Webhook failed");
            Console.WriteLine("Response: " + response.StatusCode);
            Console.WriteLine("Error message: " + response.ReasonPhrase);
            Console.ResetColor();
        }
    }
    catch (Exception ex)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(ex.Message);
        Console.ResetColor();
    }
}
//write instructions
Console.WriteLine("Press <enter> to exit");
Console.ReadLine();
