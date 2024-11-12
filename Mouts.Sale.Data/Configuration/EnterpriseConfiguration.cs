using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Mouts.Sale.Data.External;

namespace Mouts.Sale.Data.Configuration
{
    internal class EnterpriseConfiguration : IEntityTypeConfiguration<EnterpriseExternal>
    {

        public void Configure(EntityTypeBuilder<EnterpriseExternal> builder)
        {
            builder.ToTable("EnterpriseExternal");

            builder.HasKey(x => x.EnterpriseId);
            builder.Property(x => x.Name).HasColumnName("Name");
            builder.Property(x => x.Registration).HasColumnName("Registration");
            builder.Property(x => x.Description).HasColumnName("Description");


        }
    }
}
