using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mouts.Sale.Data.External;

namespace Mouts.Sale.Data.Configuration
{
    internal class CustomerConfiguration : IEntityTypeConfiguration<CustomerExternal>
    {

        public void Configure(EntityTypeBuilder<CustomerExternal> builder)
        {
            builder.ToTable("CustomerExternal");

            builder.HasKey(x => x.CustomerId);

            builder.Property(x => x.Contact).HasColumnName("Contact");
            builder.Property(x => x.Name).HasColumnName("NAME");
            builder.Property(x => x.Description).HasColumnName("Description");


        }
    }
}
