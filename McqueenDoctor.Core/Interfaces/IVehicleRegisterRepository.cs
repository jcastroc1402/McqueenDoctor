using McqueenDoctor.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace McqueenDoctor.Core.Interfaces
{
    public interface IVehicleRegisterRepository : IRepository<VehicleRegister>
    {
        Task<IEnumerable<VehicleRegister>> GetVehicleRegistersByUser(int userId);
    }
}
