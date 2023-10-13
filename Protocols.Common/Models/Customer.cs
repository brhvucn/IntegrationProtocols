using Protocols.Common.Models;
using System.Runtime.Serialization;

namespace Protocols.Common.Models
{    
    public class Customer : BaseEntity
    {                
        public Customer(int id)
        {
            if(id <= 0)
            {
                throw new ArgumentException("The id should be a positive number");
            }
            this.Id = id;
        }

        public string Name { get; set; } = string.Empty;
        
        public string Address { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public string Region { get; set; } = string.Empty;

        public string PostalCode { get; set; } = string.Empty;

        public string Country { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
    }
}
