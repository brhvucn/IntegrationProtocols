using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Dynamic;
using System.Text;

namespace RESTClient.Pages
{
    public class createModel : PageModel
    {
        public createModel()
        {
        }

        public void OnGet()
        {
        }

        public async Task OnPost()
        {
            //retrieve the data from the form
            // Use null-safe access and provide defaults to satisfy nullable reference checks
            int id = int.Parse(Request.Form["id"].FirstOrDefault() ?? "0");
            string name = Request.Form["name"].FirstOrDefault() ?? string.Empty;
            string address = Request.Form["address"].FirstOrDefault() ?? string.Empty;
            string city = Request.Form["city"].FirstOrDefault() ?? string.Empty;
            string region = Request.Form["region"].FirstOrDefault() ?? string.Empty;
            string postalcode = Request.Form["postalcode"].FirstOrDefault() ?? string.Empty;
            string country = Request.Form["country"].FirstOrDefault() ?? string.Empty;
            string email = Request.Form["email"].FirstOrDefault() ?? string.Empty;
            //create dynamic object to send
            dynamic newCustomer = new ExpandoObject();
            newCustomer.id = id;
            newCustomer.name = name;
            newCustomer.address = address;
            newCustomer.city = city;
            newCustomer.region = region;
            newCustomer.postalcode = postalcode;
            newCustomer.country = country;
            newCustomer.email = email;
            //post the customer as json to the web service
            var result = await PostJsonAsync<dynamic>("https://localhost:7298/customers", newCustomer);
            TempData["res"] = result;
        }

        private async Task<string> PostJsonAsync<T>(string endpoint, T data)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                // Serialize the data object to JSON
                string json = JsonConvert.SerializeObject(data);

                // Create a StringContent object with the JSON data
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                // Send a POST request to the specified endpoint with the JSON data
                HttpResponseMessage response = await httpClient.PostAsync(endpoint, content);

                // Check if the request was successful
                if (response.IsSuccessStatusCode)
                {
                    // Read and return the response content as a string
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    // Handle the error response, e.g., log the error or throw an exception
                    Console.WriteLine($"Error: {response.StatusCode}");
                    return $"Error: {response.StatusCode}";
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions, e.g., connection errors
                Console.WriteLine($"Exception: {ex.Message}");
                return $"Exception: {ex.Message}";
            }
        }
    }
}
