using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Moq;
using Mouts.Sale.Data.Repository.Interface;
using Mouts.Sale.Domain.Interface;
using Mouts.Sale.Domain.Services;

namespace Mouts.Sale.Test
{
    public class SalesServiceTest : IClassFixture<ConfigureServiceFixure>
    {
        private readonly ConfigureServiceFixure _configureServiceFixure;

        public SalesServiceTest(ConfigureServiceFixure configureServiceFixure)
        {
            _configureServiceFixure = configureServiceFixure;
            _configureServiceFixure.Register(SetupMock);
        }

        public void SetupMock(IServiceCollection services)
        {
            
            var saleRepositoryMock = new Mock<ISaleRepository>();
            saleRepositoryMock.Setup(s => s.GetAsync(It.Is<Guid>(c => c.ToString() == "e08043aa-dcdc-4edc-870b-4e75ddbbf8fb")))
                            .Returns(Task.FromResult(new Data.Entities.Sale { SaleId = new Guid("e08043aa-dcdc-4edc-870b-4e75ddbbf8fb"), Value = 150 }));

            saleRepositoryMock.Setup(s => s.GetAsync(It.Is<Guid>(c => c.ToString() == "0e2aa83c-0ef0-4f7c-a899-50bc9135a1ec")))
                .Returns(Task.FromResult(new Data.Entities.Sale { SaleId = new Guid("0e2aa83c-0ef0-4f7c-a899-50bc9135a1ec"), Value = 200 }));

            saleRepositoryMock.Setup(s => s.GetAsync(It.Is<Guid>(c => c.ToString() == "79957790-f94b-4235-a679-11572607b1fe")))
                .Returns(Task.FromResult(new Data.Entities.Sale { SaleId = new Guid("79957790-f94b-4235-a679-11572607b1fe"), Value = 180 }));
            services.AddScoped(c => saleRepositoryMock.Object);
        }

        [Theory]
        [MemberData(nameof(Data))]
        public async Task GetSale_Shoud_be_true(decimal value, Guid saleId)
        {
            using (var scope = _configureServiceFixure.Services.CreateScope())
            {
                var service = scope.ServiceProvider.GetService<ISaleService>();

                var result = await service.GetAsync(saleId);

                result.SalesId.ToString().Should().Be(saleId.ToString());
                result.Value.Should().Be(value);
            }
           
        }

        public static IEnumerable<object[]> Data =>
             new List<object[]>
             {
                new object[] { 150, new Guid("e08043aa-dcdc-4edc-870b-4e75ddbbf8fb")},
                new object[] { 200, new Guid("0e2aa83c-0ef0-4f7c-a899-50bc9135a1ec")},
                new object[] { 180, new Guid("79957790-f94b-4235-a679-11572607b1fe")},
             };
    }
}