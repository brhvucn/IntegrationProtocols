using Protocols.Common.Infrastructure;
using Protocols.Common.Models;

namespace GraphQLServer
{
    public class Query
    {
        private Repository<Customer> repository;
        public Query(Repository<Customer> repository)
        {
            this.repository = repository;
        }
        public IEnumerable<Customer> GetCustomers() => this.repository.GetAll();
    }
}
