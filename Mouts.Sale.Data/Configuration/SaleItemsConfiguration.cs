using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Mouts.Sale.Data.External;
using Mouts.Sale.Data.Entities;

namespace Mouts.Sale.Data.Configuration
{
    internal class SaleItemsConfiguration : IEntityTypeConfiguration<SaleItems>
    {

        public void Configure(EntityTypeBuilder<SaleItems> builder)
        {
            builder.ToTable("SaleItems");

            builder.HasKey(x => x.SaleItemsId);
            builder.Property(x => x.Amount).HasColumnName("Amount");
            builder.Property(x => x.SaleId).HasColumnName("SaleId");
            builder.Property(x => x.ProductExternalId).HasColumnName("ProductExternalId");

            builder.HasOne(x => x.Product)
             .WithMany()
             .HasForeignKey(p => p.ProductExternalId)
             .IsRequired();

            builder.HasOne(x => x.Sale)
             .WithMany()
             .HasForeignKey(p => p.SaleId)
             .IsRequired();

        }
    }
}
