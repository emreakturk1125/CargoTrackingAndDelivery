using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TekhnelogosInterviewProject.Entity.Concrete;

namespace TekhnelogosInterviewProject.Data.Configuration
{
    public class CargoConfiguration : IEntityTypeConfiguration<Cargo>
    {
        public void Configure(EntityTypeBuilder<Cargo> builder)
        {
            builder.HasKey(x => x.CargoId);
            builder.Property(x => x.CargoId).UseIdentityColumn();

            builder.Property(x => x.CargoName).IsRequired().HasMaxLength(50);

            builder.Property(x => x.CargoPrice).IsRequired().HasColumnType("decimal(18,2)");

            builder.Property(x => x.ShippingDate).HasColumnType("datetime");

            builder.Property(x => x.DeliveryDate).HasColumnType("datetime");

            builder.ToTable("Cargo");
        }
    }
}
