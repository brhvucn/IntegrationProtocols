using Protocols.Common.Models;
using Protocols.Common.Utilities;
using SOAPServer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocols.Common.Infrastructure
{
    /// <summary>
    /// Simple repository to mimic saving to a database. This is a simple placeholder for a proper implementation of data storage.
    /// </summary>
    public class Repository<T> where T : BaseEntity
    {
        private List<T> customers;
        public Repository() 
        {
            customers = new List<T>();
        }

        public void Add(T item)
        {
            var existing = Get(item.Id);
            if (existing != null)
            {
                throw new ArgumentException("An entity with this id already exists");
            }
            customers.Add(item);
        }

        public void Delete(int id)
        {
            var existingItem = customers.FirstOrDefault(x=>x.Id == id);
            if(existingItem != null)
            {
                customers.Remove(existingItem);
            }
        }

        public void Update(T entity)
        {
            var existingItem = customers.FirstOrDefault(x => x.Id == entity.Id);
            if (existingItem != null)
            {
                PropertyMapper<T, T>.Map(existingItem, entity);                
            }
        }

        public List<T> GetAll()
        {
            return customers;
        }

        public T Get(int id)
        {
            return this.customers.FirstOrDefault(x => x.Id == id);
        }

    }
}
