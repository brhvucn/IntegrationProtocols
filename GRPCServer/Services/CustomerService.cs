using Grpc.Core;

namespace GRPCServer.Services
{
    public class CustomerService : CustomersGrpc.CustomersGrpcBase
    {
        private readonly ILogger<GreeterService> _logger;
        public CustomerService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }

        public override Task<CustomerResponse> GetCustomer(CustomerRequest request, ServerCallContext context)
        {
            return Task.FromResult(new CustomerResponse
            {
                Id = "1",
                Email = "my@email.com",
                Name = "Jeff Jefferson"
            });
        }
    }
}
