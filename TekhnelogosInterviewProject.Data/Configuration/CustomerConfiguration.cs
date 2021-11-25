using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TekhnelogosInterviewProject.Entity.Concrete;

namespace TekhnelogosInterviewProject.Data.Configuration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(x => x.CustomerId);
            builder.Property(x => x.CustomerId).UseIdentityColumn();

            builder.Property(x => x.CustomerName).IsRequired().HasMaxLength(50);

            builder.Property(x => x.CustomerSurname).IsRequired().HasMaxLength(50);

            builder.Property(x => x.CustomerAddress).IsRequired().HasMaxLength(200);

            builder.Property(x => x.CreatedDate).HasColumnType("datetime");

            builder.ToTable("Customer");
        }
    }
}
