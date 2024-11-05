using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Mouts.Sale.Data.Entities;

namespace Mouts.Sale.Data.Configuration
{
    internal class SaleConfiguration : IEntityTypeConfiguration<Entities.Sale>
    {

        public void Configure(EntityTypeBuilder<Entities.Sale> builder)
        {
            builder.ToTable("Sale");

            builder.HasKey(x => x.SaleId);
            builder.Property(x => x.Value).HasColumnName("Value");
            builder.Property(x => x.Date).HasColumnName("Date");
            builder.Property(x => x.CustomerExternalId).HasColumnName("CustomerExternalId");
            builder.Property(x => x.EnterpriseId).HasColumnName("EnterpriseId");


            builder.HasMany(x => x.Items)
            .WithOne()
            .HasForeignKey(p => p.SaleId)
            .IsRequired();

            builder.HasOne(x => x.Customer)
           .WithMany()
           .HasForeignKey(p => p.CustomerExternalId)
           .OnDelete(DeleteBehavior.Cascade)
           .IsRequired();

            builder.HasOne(x => x.Enterprise)
           .WithMany()
           .HasForeignKey(p => p.EnterpriseId)
           .IsRequired();

            builder.HasMany(x => x.Discounts)
           .WithOne()
           .HasForeignKey(p => p.SaleId)
           .IsRequired();

        }
    }
}
