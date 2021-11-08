using System;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using CityLight.Models;
using CityLight.Repository;

namespace CityLight.Service
{
    public class CustomerService
    {
        public Customer Get(int id)
        {
            var dbContext = new CitylightDbContext();

            var res = dbContext.Customers.FirstOrDefault(c => c.Id == id);

            return res;
        }

        public IQueryable<Customer> Get(string name)
        {
            var dbContext = new CitylightDbContext();

            var res = dbContext.Customers.Where(c => 
                (string.IsNullOrWhiteSpace(name) || c.Name.Contains(name, StringComparison.InvariantCultureIgnoreCase)));

            return res;
        }

        public void Create(Customer customer)
        {
            var dbContext = new CitylightDbContext();

            dbContext.Customers.Add(customer);

            dbContext.SaveChanges();
        }

        public void Update(Customer customer)
        {
            var dbContext = new CitylightDbContext();

            dbContext.Customers.Update(customer);

            dbContext.SaveChanges();
        }
    }
}
