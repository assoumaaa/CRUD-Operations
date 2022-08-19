using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI__CodeFirst.Classes;
using WebAPI__CodeFirst.Model;

namespace WebAPI__CodeFirst.Repos
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext _context;

        public CustomerRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            return await _context.Customers.ToListAsync();
        }


        public Customer GetCustomerByID(int id)
        {
            var list = _context.Customers.ToList();
            return list.Find(cs => cs.customer_ID == id);
        }


        public async Task<Customer> AddCustomerAsync(Customer newCustomer)
        {
            if (newCustomer == null) return null;
            else
            {
                await _context.Customers.AddAsync(newCustomer);
                await _context.SaveChangesAsync();
                return newCustomer;
            }
        }


        public Customer UpdateCustomer(int id, Customer newCustomer)
        {
            List<Customer> list = _context.Customers.ToList();
            Customer toUpdate = list.Find(cs => cs.customer_ID == id);
            toUpdate.firstName = newCustomer.firstName;
            toUpdate.lastName = newCustomer.lastName;

            _context.SaveChanges();
            return newCustomer;
        }


        public async Task<Customer> DeleteCustomerAsync(int id)
        {
            List<Customer> list = _context.Customers.ToList();
            Customer toDelete = list.Find(cs => cs.customer_ID == id);
            _context.Customers.Remove(toDelete);
            await _context.SaveChangesAsync();
            return toDelete;
        }
    }
}
