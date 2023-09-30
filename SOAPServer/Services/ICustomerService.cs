using SOAPServer.Model;
using System.ServiceModel;

namespace SOAPServer.Services
{
    [ServiceContract]
    public interface ICustomerService
    {
        [OperationContract]
        List<Customer> GetCustomers();
    }
}
