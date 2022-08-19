global using Xunit;
using FakeItEasy;
using WebAPI__CodeFirst.Controllers;
using WebAPI__CodeFirst.Classes;
using WebAPI__CodeFirst.Repos;

namespace CustomerApi.Tests
{
    public class CustomerControllerTests
    {
        private readonly ICustomerRepository _repo;
        private readonly CustomersController _controller;
     
        public CustomerControllerTests()
        {
            _repo = A.Fake<ICustomerRepository>();
            _controller = new CustomersController(_repo);
        }
  

        [Fact]
        public async Task GetAll_Returns_All_Customers()
        {
            // Arrange
            var customers = new List<Customer>() { new Customer { customer_ID = 1 } };
            A.CallTo(() => _repo.GetAllCustomersAsync()).Returns(customers);

            // Act
            var result = await _controller.GetAllCustomersAsync();

            // Assert
            Assert.Single(result);
        }


        [Fact]
        public void GetById_Returns_Customer_WithID()
        {
            // Arrange
            var customers = new Customer { customer_ID = 1 };
            A.CallTo(() => _repo.GetCustomerByID(1)).Returns(customers);

            // Act
            var result = _controller.GetById(1);

            // Assert
            Assert.Equal(1, result.customer_ID);
        }


        [Fact]
        public async Task AddCustomer_Returns_NewCustomer()
        {
            // Arrange
            Customer newCustomer = new Customer { customer_ID = 1 };
            A.CallTo(() => _repo.AddCustomerAsync(newCustomer)).Returns(newCustomer);

            // Act
            var result = await _controller.AddCustomerAsync(newCustomer);

            // Assert
            Assert.Equal(newCustomer,result);
        }

        [Fact]
        public void UpdateCustomer_Returns_UpdatedCustomer()
        {
            // Arrange
            Customer customer = new Customer { customer_ID = 1 };
            Customer toUpdate = new Customer { customer_ID = 2 };
            A.CallTo(() => _repo.UpdateCustomer(1, toUpdate)).Returns(toUpdate);

            // Act
            var result = _controller.UpdateCustomer(1,toUpdate);

            // Assert
            Assert.Equal(toUpdate, result);
        }


        [Fact]
        public async Task DeleteCustomer_Returns_DeletedCustomer()
        {
            // Arrange
            Customer customer = new Customer { customer_ID = 1 };

            A.CallTo(() => _repo.DeleteCustomerAsync(1)).Returns(customer);

            // Act
            var result = await _controller.DeleteCustomerAsync(1);

            // Assert
            Assert.Equal(customer,result);
        }
    }
}
