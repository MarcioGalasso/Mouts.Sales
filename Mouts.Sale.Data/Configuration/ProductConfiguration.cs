using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Mouts.Sale.Data.External;

namespace Mouts.Sale.Data.Configuration
{
    internal class ProductConfiguration : IEntityTypeConfiguration<ProductExternal>
    {

        public void Configure(EntityTypeBuilder<ProductExternal> builder)
        {
            builder.ToTable("ProductExternal");

            builder.HasKey(x => x.ProductId);
            builder.Property(x => x.Value).HasColumnName("Value");
            builder.Property(x => x.Description).HasColumnName("Description");


        }
    }
}
