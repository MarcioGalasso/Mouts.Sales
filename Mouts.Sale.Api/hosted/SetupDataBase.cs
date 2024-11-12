using Microsoft.EntityFrameworkCore;
using Mouts.Sale.Data.DbContexts;
using Mouts.Sale.Data.Entities;
using Mouts.Sale.Data.External;
using Mouts.Sale.Data.Repository;
using Mouts.Sale.Data.Repository.Interface;
using Mouts.Sale.Domain.Entities;

namespace Mouts.Sale.Api.hosted
{
    public class SetupDataBase : IHostedService
    {

        
        private readonly ILogger<SetupDataBase> _logger;
        public readonly IServiceScopeFactory _serviceScopeFactory;

        public SetupDataBase(ILogger<SetupDataBase> logger, IServiceScopeFactory serviceScopeFactory)
        {
            _logger = logger;
            _serviceScopeFactory = serviceScopeFactory;
        }

      

        public async Task StartAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Setup for Sale.");
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<SaleDbContext>();
                var products = new List<ProductExternal> { new ProductExternal { Description = "Product1", Value = 50, ProductId = new Guid("9c163bb9-4d64-49c8-bdc9-af508d5285cb") }, new ProductExternal { Description = "Product2", Value = 100, ProductId = new Guid("4633942c-30d7-49ac-8463-f8e6f2e6d797") } };
                var enterprise = new EnterpriseExternal { Description = "Enterprise", Name = "EnterpriseName", Registration = "1232134", EnterpriseId = new Guid("7fc065cc-8b6d-429b-ad8f-4f77aff4faba") };
                var custumer = new CustomerExternal { Name = "Custumer", CustomerId = new Guid("562716c1-d97e-4346-acec-ec1e1f2ca26c") };

                var sale = new Data.Entities.Sale
                {
                    CustomerExternalId = new Guid("562716c1-d97e-4346-acec-ec1e1f2ca26c"),
                    Date = DateTime.Now,
                    EnterpriseId = new Guid("7fc065cc-8b6d-429b-ad8f-4f77aff4faba"),
                    SaleId = new Guid("e585e64a-d5ec-41a5-9062-0cab9d192719"),
                    Value = 150,
                    Items = new List<Data.Entities.SaleItems> { new Data.Entities.SaleItems {SaleItemsId = new Guid("58e1df1c-aa34-418c-a12a-eb9ba4b7b336"),
                                                                                            ProductExternalId= new Guid("4633942c-30d7-49ac-8463-f8e6f2e6d797")
                                                                                            ,Amount=1 },
                                                               new Data.Entities.SaleItems {SaleItemsId = new Guid("dfc35304-75bd-4303-99f7-85e9adf19981"),
                                                                                            ProductExternalId= new Guid("9c163bb9-4d64-49c8-bdc9-af508d5285cb"),Amount=1 }}
                };
                await context.Set<ProductExternal>().AddRangeAsync(products);
                await context.Set<EnterpriseExternal>().AddRangeAsync(enterprise);
                await context.Set<CustomerExternal>().AddRangeAsync(custumer);
                await context.Set<Data.Entities.Sale>().AddRangeAsync(sale);
            }
           
           
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }


}
