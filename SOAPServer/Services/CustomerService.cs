using SOAPServer.Model;

namespace SOAPServer.Services
{
    public class CustomerService : ICustomerService
    {
        public List<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer{Address="Vesterbro 100", City="Aalborg", Country = "Denmark", Id = 1, Name="Hello World Developement", Email="hello@helloworlddev.dk", PostalCode="9000", Region="Northern Jutland"}
            };
        }
    }
}
