
using Microsoft.EntityFrameworkCore;
using Mouts.Sale.Data.DbContexts;
using Mouts.Sale.Data.External;
using Mouts.Sale.Data.Repository.Base;
using Mouts.Sale.Data.Repository.Interface;

namespace Mouts.Sale.Data.Repository
{
    public class ProductExternalRepository : BaseRepository<External.ProductExternal>, IProductExternalRepository
    {
        public ProductExternalRepository(SaleDbContext context) : base(context)
        {
        }


      
    }
}
