using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI__CodeFirst.Classes;
using WebAPI__CodeFirst.Repos;

namespace WebAPI__CodeFirst.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/customers")]
    public class CustomersController : Controller
    {
        private readonly ICustomerRepository _customerRepo;   
        public CustomersController(ICustomerRepository customerRepo)
        {
            _customerRepo = customerRepo;
        }


        [HttpGet]
        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            return await _customerRepo.GetAllCustomersAsync();
        }


        [HttpGet("{id}")]
        public Customer GetById(int id)
        {
            return _customerRepo.GetCustomerByID(id);
        }


        [HttpPost]  
        public async Task<Customer> AddCustomerAsync([FromBody] Customer newCustomer)
        {
            return await _customerRepo.AddCustomerAsync(newCustomer);
        } 


        [HttpPut("{id}")]
        public Customer UpdateCustomer(int id, [FromBody] Customer value)
        {
            return _customerRepo.UpdateCustomer(id, value);
        }


        [HttpDelete("{id}")]
        public async Task<Customer> DeleteCustomerAsync(int id)
        {
            return await _customerRepo.DeleteCustomerAsync(id);
        }
    }
}
