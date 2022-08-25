using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI__CodeFirst.Classes;

namespace WebAPI__CodeFirst.Repos
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAllCustomersAsync();

        Customer GetCustomerByID(int id);

        Task<Customer> AddCustomerAsync(Customer newCustomer);

        Customer  UpdateCustomer(int id,Customer newCustomer);

        Task<Customer> DeleteCustomerAsync(int id);
    }
}
