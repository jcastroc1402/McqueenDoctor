using McqueenDoctor.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace McqueenDoctor.Core.Interfaces
{
    public interface IVehicleRegisterService
    {
        Task<IEnumerable<VehicleRegister>> GetVehicleRegisters();

        Task<VehicleRegister> GetVehicleRegister(int id);

        Task<bool> InsertVehicleRegister(VehicleRegister vehicleRegister);

        Task<bool> UpdateVehicleRegister(VehicleRegister vehicleRegister);

        Task<bool> UpdateVehicleRegisterExcel(List<VehicleRegister> vehicleRegisters);

        Task<bool> DeleteVehicleRegister(int id);
    }
}
