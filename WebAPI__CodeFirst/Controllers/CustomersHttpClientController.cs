using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI__CodeFirst.Model;

namespace WebAPI__CodeFirst.Controllers
{
    [ApiController]
    [Route("api/client/customer")]
    public class CustomersHttpClientController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CustomersHttpClientController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        [HttpPost]
        public async Task<Customer> CreateCustomerAsync([FromBody] Customer newCustomer)
        {
            var http = _httpClientFactory.CreateClient();
            await http.PostAsJsonAsync("https://localhost:5001/api/customers", newCustomer);
            return newCustomer;
        }
    }
}
