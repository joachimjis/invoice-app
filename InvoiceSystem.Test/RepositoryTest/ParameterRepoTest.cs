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
    public class ParameterRepoTest
    {

        private readonly ServiceProvider _serviceProvider;

        private readonly ApplicationContext _context;
        private readonly ParameterRepository _sut;

        public ParameterRepoTest()
        {
            _serviceProvider = new ServiceCollection()
                 .AddTransient<ParameterRepository>()
                 .AddDbContext<ApplicationContext>(options => options.UseInMemoryDatabase(Guid.NewGuid().ToString()), ServiceLifetime.Transient)
                 .BuildServiceProvider();

            _sut = _serviceProvider.GetService<ParameterRepository>();
            _context = _serviceProvider.GetService<ApplicationContext>();
        }

        [Fact]
        public async Task Should_Get_ParameterAsync()
        {
            // arrange
            var expected = Builder<ParameterModel>.CreateNew().Build();

            await _context.Parametres.AddAsync(new Parametre
            {
                NomSociete = expected.CompanyName,
                Id = expected.ParametreId,
                Adresse = expected.Address,
                CodePostal = expected.PostalCode,
                Email = expected.Email,
                LieuPostal = expected.PostalPlace,
                NumeroTelephone = expected.Telephone,
                Rib = expected.Rib
            });

            await _context.SaveChangesAsync();

            // act
            var actual = await _sut.GetParameterAsync();

            // assert
            Assert.Equal(expected.CompanyName, actual.CompanyName);
            Assert.Equal(expected.Telephone, actual.Telephone);
            Assert.Equal(expected.Rib, actual.Rib);
            Assert.Equal(expected.Address, actual.Address);
            Assert.Equal(expected.PostalCode, actual.PostalCode);
            Assert.Equal(expected.Email, actual.Email);
            Assert.Equal(expected.PostalPlace, actual.PostalPlace);
        }

        //[Fact]
        //public async Task Should_Update_ParameterAsync()
        //{
        //    // arrange
        //    int id = 2;

        //    var parameterModel = Builder<ParameterModel>
        //        .CreateNew()
        //        .With(d => d.ParametreId = id)
        //        .Build();

        //    await _context.Parametres.AddAsync(new Parametre
        //    {
        //        NomSociete = parameterModel.NomSociete,
        //        ParametreId = parameterModel.ParametreId,
        //        Adresse = parameterModel.Adresse,
        //        CodePostal = parameterModel.CodePostal,
        //        Email = parameterModel.Email,
        //        LieuPostal = parameterModel.LieuPostal,
        //        NumeroTelephone = parameterModel.NumeroTelephone,
        //        Rib = parameterModel.Rib
        //    });

        //    await _context.SaveChangesAsync();

        //    var expected = Builder<ParameterModel>
        //        .CreateNew()
        //            .With(d => d.ParametreId = id)
        //            .With(d => d.Adresse = "Adress")
        //            .With(d => d.CodePostal = "Code postal")
        //            .With(d => d.Email = "Email")
        //            .With(d => d.LieuPostal = "Lieu postal")
        //            .With(d => d.NomSociete = "Nom société")
        //            .With(d => d.NumeroTelephone = 123456)
        //            .With(d => d.Rib = "rib")
        //        .Build();

        //    // act
        //    await _sut.UpdateParameterAsync(expected);

        //    // assert
        //    var actual = await _context.Parametres.FirstOrDefaultAsync();

        //    AssertParameters(expected, actual);
        //}

        private void AssertParameters(ParameterModel expected, Parametre actual)
        {
            Assert.Equal(expected.CompanyName, actual.NomSociete);
            Assert.Equal(expected.Telephone, actual.NumeroTelephone);
            Assert.Equal(expected.Rib, actual.Rib);
            Assert.Equal(expected.Address, actual.Adresse);
            Assert.Equal(expected.PostalCode, actual.CodePostal);
            Assert.Equal(expected.Email, actual.Email);
            Assert.Equal(expected.PostalPlace, actual.LieuPostal);
        }
    }
}
