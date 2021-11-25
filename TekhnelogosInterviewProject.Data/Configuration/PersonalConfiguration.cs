using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TekhnelogosInterviewProject.Entity.Concrete;

namespace TekhnelogosInterviewProject.Data.Configuration
{
    public class PersonalConfiguration : IEntityTypeConfiguration<Personal>
    {
        public void Configure(EntityTypeBuilder<Personal> builder)
        {
            builder.HasKey(x => x.PersonalId);
            builder.Property(x => x.PersonalId).UseIdentityColumn();

            builder.Property(x => x.PersonalName).IsRequired().HasMaxLength(50);

            builder.Property(x => x.PersonalSurname).IsRequired().HasMaxLength(50); 

            builder.Property(x => x.UserName).IsRequired().HasMaxLength(50);

            builder.Property(x => x.UserPassword).IsRequired().HasMaxLength(50);

            builder.Property(x => x.CreatedDate).HasColumnType("datetime");

            builder.ToTable("Personal");
        }
    }
}
