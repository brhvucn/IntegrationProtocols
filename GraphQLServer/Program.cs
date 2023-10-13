using GraphQLServer;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Protocols.Common.Infrastructure;
using Protocols.Common.Models;
using System.Runtime.CompilerServices;

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
//enable GraphQL query
builder.Services.AddGraphQLServer()
    .AddQueryType<Query>();

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

//create a new customer
app.MapPost("/customers", (Repository<Customer> customerRepository, Customer customer) =>
{
    customerRepository.Add(customer);
})
.WithName("CreateCustomer")
.WithOpenApi();

//seed the database
app.MapPost("/seed", (Repository<Customer> customerRepository) =>
{
    try
    {
        customerRepository.Add(new Customer(1) { Name = "Nordic Welding", Address = "Sofiendalsvej 58", City = "Aalborg", Country = "Denmark", Email = "info@nordicwelding.dk", PostalCode = "9100", Region = "Northern Jutland" });
        customerRepository.Add(new Customer(2) { Name = "Horse Care", Address = "granvej 8", City = "Ulsted", Country = "Denmark", Email = "info_hestepleje@gmail.com", PostalCode = "9370", Region = "Northern Jutland" });
        customerRepository.Add(new Customer(3) { Name = "Pepes Pizza", Address = "Vesterbro 14", City = "Aalborg", Country = "Denmark", Email = "info@pepespizza.dk", PostalCode = "9000", Region = "Northern Jutland" });
        return "OK. Seeded.";
    }
    catch(Exception ex)
    {
        return ex.Message;
    }
})
.WithName("SeedCustomers")
.WithOpenApi();

//map GraphQL
app.MapGraphQL();

app.Run();

