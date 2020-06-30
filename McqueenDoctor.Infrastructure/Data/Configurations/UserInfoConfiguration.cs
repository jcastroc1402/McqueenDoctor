using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using McqueenDoctor.Core.Entities;

namespace McqueenDoctor.Infrastructure.Data.Configurations
{
    public class UserInfoConfiguration : IEntityTypeConfiguration<UserInfo>
    {
        public void Configure(EntityTypeBuilder<UserInfo> builder)
        {
            builder.ToTable("UsersInfo");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("UserInfoId");

            builder.Property(e => e.FirstName)
                .HasColumnName("FirstName")
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.LastName)
                .HasColumnName("LastName")
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Email)
                .HasColumnName("Email")
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Rol)
                .HasColumnName("Rol")
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);
        }
    }
}
