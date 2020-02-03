using System.Linq;
using System.Threading.Tasks;
using FizzWare.NBuilder;
using InvoiceSystem.Business.IRepository;
using InvoiceSystem.Business.Models;
using InvoiceSystem.Business.Services;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Xunit;

namespace InvoiceSystem.Test
{
    public class CustomerServiceTest
    {
        private readonly ServiceProvider _serviceProvider;
        private readonly CustomerService _sut;

        private readonly Mock<ICustomerRepository> _mockCustomerRepo = new Mock<ICustomerRepository>();

        public CustomerServiceTest()
        {
            _serviceProvider = new ServiceCollection()
                 .AddTransient(sp => _mockCustomerRepo.Object)
                 .AddTransient<CustomerService>()
                 .BuildServiceProvider();

            _sut = _serviceProvider.GetService<CustomerService>();
        }

        [Fact]
        public async Task Should_Get_Company_ParameterAsync()
        {
            // arrange
            var customers = Builder<CustomerModel>.CreateListOfSize(2).Build().ToList();
            int userId = 1;

            _mockCustomerRepo.Setup(x => x.GetCustomersAsync(userId)).ReturnsAsync(customers);

            // act
            var actual = await _sut.GetCustomersAsync(userId);

            // assert
            _mockCustomerRepo.Verify(x => x.GetCustomersAsync(userId), Times.Once);
        }

        [Fact]
        public async Task Should_Create_Customer()
        {
            // arrange
            var customerModel = Builder<CustomerModel>.CreateNew().Build();

            _mockCustomerRepo.Setup(x => x.CreateCustomerAsync(customerModel));

            // act
            await _sut.CreateCustomerAsync(customerModel);

            // assert
            _mockCustomerRepo.Verify(x => x.CreateCustomerAsync(customerModel), Times.Once);
        }
    }
}
