
using Mouts.Sale.Data.DbContexts;
using Mouts.Sale.Data.Repository.Base;
using Mouts.Sale.Data.Repository.Interface;

namespace Mouts.Sale.Data.Repository
{
    public class SaleRepository : BaseRepository<Entities.Sale>, ISaleRepository
    {
        public SaleRepository(SaleDbContext context) : base(context)
        {
        }

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
