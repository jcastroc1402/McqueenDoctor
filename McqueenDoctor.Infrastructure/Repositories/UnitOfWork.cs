using McqueenDoctor.Core.Entities;
using McqueenDoctor.Core.Interfaces;
using McqueenDoctor.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace McqueenDoctor.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext Context;
        private IVehicleRegisterRepository _vehiculeRegisterRepository;
        private IRepository<UserInfo> _userInfoRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            Context = context;
        }

        public IVehicleRegisterRepository VehiculeRegisterRepository => _vehiculeRegisterRepository ?? new VehicleRegisterRepository(Context);
        public IRepository<UserInfo> UserInfoRepository => _userInfoRepository ?? new BaseRepository<UserInfo>(Context);

        public void SaveChanges()
        {
            Context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await Context.SaveChangesAsync();
        }

        public void Dispose()
        {
            if (Context != null)
                Context.Dispose();
        }
    }
}
