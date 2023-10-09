using Protocols.Common.Infrastructure;
using SOAPServer.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton(typeof(Repository<>));
//enable CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder
            .AllowAnyOrigin() // Change to specific origins if needed
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
//use CORS
app.UseCors("AllowAll");
//get all customers
app.MapGet("/customers", (Repository<Customer> customerRepository) =>
{
    return customerRepository.GetAll();
})
.WithName("GetCustomers")
.WithOpenApi();

//get all customers
app.MapGet("/customer/{id}", (Repository<Customer> customerRepository, int id) =>
{
    return customerRepository.Get(id);    
})
.WithName("GetCustomer")
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
