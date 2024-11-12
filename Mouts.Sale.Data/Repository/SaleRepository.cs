
using Microsoft.EntityFrameworkCore;
using Mouts.Sale.Data.DbContexts;
using Mouts.Sale.Data.External;
using Mouts.Sale.Data.Repository.Base;
using Mouts.Sale.Data.Repository.Interface;

namespace Mouts.Sale.Data.Repository
{
    public class SaleRepository : BaseRepository<Entities.Sale>, ISaleRepository
    {
        private readonly IProductExternalRepository _productExternalRepository;

        public SaleRepository(SaleDbContext context, IProductExternalRepository productExternalRepository) : base(context)
        {
            _productExternalRepository = productExternalRepository;
        }


        public override async Task<bool> AddAsync(Entities.Sale entity)
        {
            var productsIds = entity.Items.Select(c => c.ProductExternalId).ToList();
            var products = await _productExternalRepository.GetAllAsync(c=> c.Where(t=> productsIds.Contains(t.ProductId)));
            
            CalculateValue(entity, products.ToList());
            CalculateDiscounts(entity);
            return await base.AddAsync(entity);
        }

        private static void CalculateValue(Entities.Sale entity, List<ProductExternal> products)=>
            entity.Items.ForEach(t =>
            {
                
                var product = products.FirstOrDefault(c => c.ProductId == t.ProductExternalId);
                entity.Value += (product?.Value??0) * t.Amount;
            });

        private static void CalculateDiscounts(Entities.Sale entity) =>
           entity.Discounts.ForEach(t => entity.Value -= t.Value);

        public override async Task<bool> RemoveByIdAsync(Guid id)
        {
            var sale = await GetAsync(id);
            sale.Items.Clear();
            sale.Discounts.Clear();

            DatabaseContext.Remove(sale);
            DatabaseContext.SaveChanges();
            return true;
        }
    }
}
