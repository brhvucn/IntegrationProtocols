using Protocols.Common.Infrastructure;
using SOAPServer.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton(typeof(Repository<>));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//get all customers
app.MapGet("/customers", (Repository<Customer> customerRepository) =>
{
    return customerRepository.GetAll();
    //var customers = new List<Customer>();
    //customers.Add();
    //return customers;
})
.WithName("GetCustomers")
.WithOpenApi();

//add new customer
app.MapPost("/customers", (Repository<Customer> customerRepository, Customer customer) =>
{    
    customerRepository.Add(customer);
}).
WithName("SaveCustomer")
.WithOpenApi();

//update customer, change country to Sweden
app.MapPut("/customer/{id}", (Repository<Customer> customerRepository, Customer customer, int id) =>
{    
    customerRepository.Update(customer);
}).
WithName("UpdateCustomer")
.WithOpenApi();

//Delete the customer
app.MapDelete("/customer/{id}", (Repository<Customer> customerRepository, int id) =>
{    
    customerRepository.Delete(id);
}).
WithName("DeleteCustomer")
.WithOpenApi();

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
