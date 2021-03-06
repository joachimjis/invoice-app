using System;
using InvoiceSystem.Business.Models;
using InvoiceSystem.Infrastructure;
using InvoiceSystem.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using FizzWare.NBuilder;
using InvoiceSystem.Infrastructure.Models;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceSystem.Test
{
    public class CustomerRepoTest
    {

        private readonly ServiceProvider _serviceProvider;

        private readonly ApplicationContext _context;
        private readonly CustomerRepository _sut;

        private const int UserId = 2;

        public CustomerRepoTest()
        {
            _serviceProvider = new ServiceCollection()
                 .AddTransient<CustomerRepository>()
                 .AddDbContext<ApplicationContext>(
                    options => options.UseInMemoryDatabase(
                        Guid.NewGuid().ToString()),
                        ServiceLifetime.Transient)
                 .BuildServiceProvider();

            _sut = _serviceProvider.GetService<CustomerRepository>();
            _context = _serviceProvider.GetService<ApplicationContext>();
        }

        [Fact]
        public async Task Should_Get_Customers()
        {
            // arrange
            var customers = Builder<Client>.CreateListOfSize(2)
                .All()
                .With(d => d.Id + 1)
                .With(d => d.UserId = UserId)
                .Build();

            await _context.Clients.AddRangeAsync(customers);
            await _context.SaveChangesAsync();

            // act
            var actual = await _sut.GetCustomersAsync(UserId);

            // assert
            Assert.Equal(2, actual.Count);
        }

        [Fact]
        public async Task Should_Create_CustomerAsync()
        {
            // arrange
            var customerModel = Builder<CustomerModel>.CreateNew().Build();

            // act
            await _sut.CreateCustomerAsync(customerModel);

            //assert
            var customers = _context.Clients.ToList();
            Assert.Equal(1, customers.Count);
        }

        [Fact]
        public async Task Should_Get_Customer_Async()
        {
            // arrange
            int customerId = 2;

            var customer = Builder<Client>.CreateNew().With(d => d.Id = customerId).Build();
            await _context.Clients.AddAsync(customer);
            await _context.SaveChangesAsync();

            // act
            var actual = await _sut.GetCustomerAsync(customerId);

            // assert
            Assert.NotNull(actual);

            Assert.Equal(customer.NomSociete, actual.Name);
            Assert.Equal(customer.NumeroTelephone, actual.Telephone);
            Assert.Equal(customer.Email, actual.Email);
            Assert.Equal(customer.SecteurActivite, actual.ActivitySector);
            Assert.Equal(customer.RCS, actual.Rcs);
            Assert.Equal(customer.AdressePhysique, actual.Address);
            Assert.Equal(customer.Commune, actual.Suburb);
            Assert.Equal(customer.Ile, actual.Island);
            Assert.Equal(customer.Commentaire, actual.Comments);
        }

        [Fact]
        public async Task Should_Not_get_Customer_Async()
        {
            // arrange
            int customerId = 2;

            // act
            var actual = await _sut.GetCustomerAsync(customerId);

            // assert
            Assert.Null(actual);
        }
    }
}
