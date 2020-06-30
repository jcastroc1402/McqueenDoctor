using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using McqueenDoctor.Core.Entities;

namespace McqueenDoctor.Infrastructure.Data.Configurations
{
    public class VehicleRegisterConfiguration : IEntityTypeConfiguration<VehicleRegister>
    {
        public void Configure(EntityTypeBuilder<VehicleRegister> builder)
        {
            builder.ToTable("VehicleRegisters");

            builder.HasKey(v => v.Id);

            builder.Property(v => v.Id)
                .HasColumnName("VehicleRegisterId");

            builder.Property(e => e.Color)
                .HasColumnName("Color")
                .IsRequired()
                .HasMaxLength(15)
                .IsUnicode(false);

            builder.Property(e => e.Model)
                .HasColumnName("Model")
                .IsRequired();

            builder.Property(e => e.Maker)
                .HasColumnName("Maker")
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);

            builder.Property(e => e.Img)
                .HasColumnName("Img")
                .IsRequired()
                .HasMaxLength(500)
                .IsUnicode(false);

            builder.Property(e => e.State)
                .HasColumnName("State")
                .HasColumnType("bit");

            builder.Property(e => e.DateInsertion)
                .HasColumnName("DateInsertion")
                .HasColumnType("datetime");

            builder.Property(e => e.Value)
                .HasColumnName("Value")
                .HasColumnType("float");

            builder.HasOne(v => v.UserInfo)
                .WithMany(u => u.VehicleRegisters)
                .HasForeignKey(v => v.UserInfoId);
        }
    }
}
