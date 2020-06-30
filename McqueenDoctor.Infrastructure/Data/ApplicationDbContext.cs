using System;
using Microsoft.EntityFrameworkCore;
using McqueenDoctor.Infrastructure.Data.Configurations;
using McqueenDoctor.Core.Entities;

namespace McqueenDoctor.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {

        public DbSet<VehicleRegister> VehicleRegisters { get; set; }
        public DbSet<UserInfo> UsersInfo { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new VehicleRegisterConfiguration());
            modelBuilder.ApplyConfiguration(new UserInfoConfiguration());
        }
    }
}
