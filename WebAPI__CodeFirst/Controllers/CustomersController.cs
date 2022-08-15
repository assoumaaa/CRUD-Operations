using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI__CodeFirst.Authentication;
using WebAPI__CodeFirst.Model;

namespace WebAPI__CodeFirst.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/customers")]
    public class CustomersController : Controller
    {
        private readonly DataContext _context;

        public CustomersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Customer> GetAll()
        {
            return _context.Customers.ToList();
        }


        [HttpGet("{id}")]
        public Customer GetById(int id)
        {      
            var list = _context.Customers.ToList();
            return list.Find(cs => cs.customer_ID == id);   
        }


        [HttpPost]
        public Customer AddCustomer([FromBody] Customer newCustomer)
        {
            if (newCustomer == null) return null;
            else
            {
                _context.Customers.Add(newCustomer);
                _context.SaveChanges();
                return newCustomer;
            } 
        }

        [HttpPut("{id}")]
        public Customer UpdateCustomer(int id, [FromBody] Customer value)
        {         
            List<Customer> list = _context.Customers.ToList();
            Customer toUpdate = list.Find(cs => cs.customer_ID == id);
            toUpdate.firstName = value.firstName;
            toUpdate.lastName = value.lastName;

            _context.SaveChanges();
            return toUpdate;     
        }


        [HttpDelete("{id}")]
        public Customer DeleteCustomer(int id)
        {       
            List<Customer> list = _context.Customers.ToList();
            Customer toDelete = list.Find(cs => cs.customer_ID == id);
            _context.Customers.Remove(toDelete);
            _context.SaveChanges();
            return toDelete;    
        }
    }
}
