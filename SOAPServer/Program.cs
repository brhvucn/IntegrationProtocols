using SoapCore;
using SoapCore.Extensibility;
using SOAPServer.Services;
using System.ServiceModel;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ICustomerService, CustomerService>();
builder.Services.AddSoapCore();
builder.Services.AddMvc();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapControllers();
app.UseEndpoints(endpoints => {
    endpoints.UseSoapEndpoint<ICustomerService>("/Service.asmx", 
        new SoapEncoderOptions(), 
        SoapSerializer.DataContractSerializer);
});

app.Run();
