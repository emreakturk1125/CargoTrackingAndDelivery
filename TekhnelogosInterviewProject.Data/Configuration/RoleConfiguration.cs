using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TekhnelogosInterviewProject.Entity.Concrete;

namespace TekhnelogosInterviewProject.Data.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(x => x.RoleId);
            builder.Property(x => x.RoleId).UseIdentityColumn();

            builder.Property(x => x.RoleName).IsRequired().HasMaxLength(50);

            builder.ToTable("Role");
        }
    }
}
