using CityLight.Models;
using System.Linq;

namespace CityLight.Models.Interfaces
{
    public interface ICustomerService
    {
        void Create(Customer customer);
        Customer Get(int id);
        IQueryable<Customer> Get(string name);
        void Update(Customer customer);
    }
}