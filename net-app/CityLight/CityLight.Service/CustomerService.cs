using System;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using CityLight.Models;
using CityLight.Models.Interfaces;
using CityLight.Repository;

namespace CityLight.Service
{
    public class CustomerService : ICustomerService
    {
        public Customer Get(int id)
        {
            var dbContext = new CitylightDbContext();

            var res = dbContext.Customers.FirstOrDefault(c => c.IsActive && c.Id == id);

            return res;
        }

        public IQueryable<Customer> Get(string name)
        {
            var dbContext = new CitylightDbContext();

            dbContext.Seed();

            var res = dbContext.Customers.Where(c =>
                c.IsActive &&
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
