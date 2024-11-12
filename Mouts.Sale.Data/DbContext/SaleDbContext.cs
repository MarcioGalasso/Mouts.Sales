using Microsoft.EntityFrameworkCore;


namespace Mouts.Sale.Data.DbContexts
{
    public class SaleDbContext : DbContext
    {
        public SaleDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Inject all map classes of EF
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Entities.Sale).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
