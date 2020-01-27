using System;
using System.Threading.Tasks;
using FizzWare.NBuilder;
using InvoiceSystem.Business.IRepository;
using InvoiceSystem.Business.Models;
using InvoiceSystem.Business.Services;
using InvoiceSystem.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Xunit;

namespace InvoiceSystem.Test
{
    public class ParameterServiceTest
    {
        private readonly ServiceProvider _serviceProvider;
        private readonly ParameterService _sut;

        private readonly Mock<IParameterRepository> _mockParameterRepo = new Mock<IParameterRepository>();

        public ParameterServiceTest()
        {
            _serviceProvider = new ServiceCollection()
                 .AddTransient(sp => _mockParameterRepo.Object)
                 .AddTransient<ParameterService>()
                 .BuildServiceProvider();

            _sut = _serviceProvider.GetService<ParameterService>();
        }

        [Fact]
        public async Task Should_Get_Company_ParameterAsync()
        {
            // arrange
            var parameterModel = Builder<ParameterModel>.CreateNew().Build();

            _mockParameterRepo.Setup(x => x.GetParameterAsync()).ReturnsAsync(parameterModel);

            // act
            var actual = await _sut.GetCompanyParameterAsync();

            // assert
            _mockParameterRepo.Verify(x => x.GetParameterAsync(), Times.Once);
        }

        [Fact]
        public async Task Should_Update_ParameterAsync()
        {
            // arrange
            var parameterModel = Builder<ParameterModel>.CreateNew().Build();
            _mockParameterRepo.Setup(x => x.UpdateParameterAsync(parameterModel.ParametreId, parameterModel));

            // act
            await _sut.UpdateCompanyParameterAsync(parameterModel.ParametreId, parameterModel);

            // assert
            _mockParameterRepo.Verify(x => x.UpdateParameterAsync(parameterModel.ParametreId, parameterModel), Times.Once);

        }
    }
}
