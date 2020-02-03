using System.Threading.Tasks;
using FizzWare.NBuilder;
using InvoiceSystem.Business;
using InvoiceSystem.Business.IRepository;
using InvoiceSystem.Business.Models;
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
            int userId = 1;

            _mockParameterRepo.Setup(x => x.GetParameterAsync(userId)).ReturnsAsync(parameterModel);

            // act
            var actual = await _sut.GetCompanyParameterAsync(userId);

            // assert
            _mockParameterRepo.Verify(x => x.GetParameterAsync(userId), Times.Once);
        }

        [Fact]
        public void Should_Update_ParameterAsync()
        {
            // arrange
            var parameterModel = Builder<ParameterModel>.CreateNew().Build();

            _mockParameterRepo.Setup(x => x.UpdateParameter(parameterModel));

            // act
            _sut.UpdateCompanyParameter(parameterModel);

            // assert
            _mockParameterRepo.Verify(x => x.UpdateParameter(parameterModel), Times.Once);

        }
    }
}
