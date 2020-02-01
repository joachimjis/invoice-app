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
    public class UserRepoTest
    {

        private readonly ServiceProvider _serviceProvider;

        private readonly ApplicationContext _context;
        private readonly UserRepository _sut;

        public UserRepoTest()
        {
            _serviceProvider = new ServiceCollection()
                 .AddTransient<UserRepository>()
                 .AddDbContext<ApplicationContext>(options => options.UseInMemoryDatabase(Guid.NewGuid().ToString()), ServiceLifetime.Transient)
                 .BuildServiceProvider();

            _sut = _serviceProvider.GetService<UserRepository>();
            _context = _serviceProvider.GetService<ApplicationContext>();
        }

        [Fact]
        public async Task Should_Get_UserAsync()
        {
            // arrange
            var expected = Builder<Infrastructure.Models.User>.CreateNew().Build();

            await _context.Users.AddAsync(expected);

            await _context.SaveChangesAsync();

            // act
            var actual = await _sut.GetUserAsync(expected.Username, expected.Password);

            // assert
            Assert.NotNull(actual);
            Assert.Equal(expected.Username, actual.Username);
            Assert.Equal(expected.FirstName, actual.FirstName);
            Assert.Equal(expected.LastName, actual.LastName);
            Assert.Equal(expected.Password, actual.Password);
            Assert.Equal(expected.Token, actual.Token);
        }

        [Fact]
        public async Task Should_Not_Get_Any_UserAsync()
        {
            // arrange
            string userName = "john";
            string password = "doe";

            // act
            var actual = await _sut.GetUserAsync(userName, password);

            // assert
            Assert.Null(actual);
        }
    }
}
