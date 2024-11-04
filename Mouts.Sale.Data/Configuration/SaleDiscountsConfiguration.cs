using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Mouts.Sale.Data.External;
using Mouts.Sale.Data.Entities;

namespace Mouts.Sale.Data.Configuration
{
    internal class SaleDiscountsConfiguration : IEntityTypeConfiguration<SaleDiscounts>
    {

        public void Configure(EntityTypeBuilder<SaleDiscounts> builder)
        {
            builder.ToTable("SaleDiscounts");

            builder.HasKey(x => x.SaleDiscountsId);
            builder.Property(x => x.Value).HasColumnName("Value");
            builder.Property(x => x.Description).HasColumnName("Description");
            builder.Property(x => x.SaleId).HasColumnName("SaleId");

            builder.HasOne(x => x.Sale)
               .WithMany()
               .HasForeignKey(p => p.SaleId)
               .IsRequired();
        }
    }
}
