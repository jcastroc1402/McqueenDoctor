using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using McqueenDoctor.Core.Entities;
using McqueenDoctor.Core.Enumerations;

namespace McqueenDoctor.Infrastructure.Data.Configurations
{
    public class SecurityConfiguration : IEntityTypeConfiguration<Security>
    {
        public void Configure(EntityTypeBuilder<Security> builder)
        {
            builder.ToTable("Securities");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.User)
                .HasColumnName("Color")
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(false);

            builder.Property(s => s.Username)
                .HasColumnName("Username")
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(false);

            builder.Property(s => s.Password)
                .HasColumnName("Password")
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false);

            //Se realiza una conversion de tipos
            builder.Property(s => s.Role)
                .IsRequired()
                .HasConversion(
                    x => x.ToString(),
                    x => (Role)Enum.Parse(typeof(Role), x)
                );
        }
    }
}
