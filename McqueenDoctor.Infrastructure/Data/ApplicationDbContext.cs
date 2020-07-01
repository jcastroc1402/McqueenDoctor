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
        public DbSet<Security> Securities { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new VehicleRegisterConfiguration());
            modelBuilder.ApplyConfiguration(new UserInfoConfiguration());
            modelBuilder.ApplyConfiguration(new SecurityConfiguration());

            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());        Tomar las configuraciones desde el ensamblador para evitar agregarlas una a una
        }
    }
}
