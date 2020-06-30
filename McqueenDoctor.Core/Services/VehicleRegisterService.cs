using McqueenDoctor.Core.Entities;
using McqueenDoctor.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace McqueenDoctor.Core.Services
{
    public class VehicleRegisterService : IVehicleRegisterService
    {
        private readonly IUnitOfWork UnitOfWork;

        public VehicleRegisterService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public async Task<bool> DeleteVehicleRegister(int id)
        {
            try
            {
                await UnitOfWork.VehiculeRegisterRepository.Delete(id);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<VehicleRegister> GetVehicleRegister(int id)
        {
            return await UnitOfWork.VehiculeRegisterRepository.GetById(id);
        }

        public async Task<IEnumerable<VehicleRegister>> GetVehicleRegisters()
        {
            return await UnitOfWork.VehiculeRegisterRepository.GetAll();
        }

        public async Task<bool> InsertVehicleRegister(VehicleRegister vehicleRegister)
        {
            var getAll = await UnitOfWork.VehiculeRegisterRepository.GetAll();
            var coincidence = getAll.Where(x => x.Matricule == vehicleRegister.Matricule && x.State == true).Count();

            if (coincidence == 0)
            {
                vehicleRegister.State = true;
                ValueValidation(vehicleRegister);

                await UnitOfWork.VehiculeRegisterRepository.Add(vehicleRegister);
                await UnitOfWork.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<bool> UpdateVehicleRegister(VehicleRegister vehicleRegister)
        {
            try
            {
                ValueValidation(vehicleRegister);

                UnitOfWork.VehiculeRegisterRepository.Update(vehicleRegister);
                await UnitOfWork.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateVehicleRegisterExcel(List<VehicleRegister> vehicleRegisters)
        {
            try
            {
                var actualRegisters = await this.GetVehicleRegisters();

                foreach (VehicleRegister register in vehicleRegisters)
                {
                    var coincidence = actualRegisters.Where(x => x.Matricule == register.Matricule).ToList();

                    //Si se encuentran en el excel y no se encuentran en la bd
                    if (coincidence.Count() == 0)
                        await this.InsertVehicleRegister(register);
                    else if (coincidence.Count() == 1)                      //Si se encuentran en la bd y en el excel
                    {
                        coincidence.First().Color = register.Color;
                        coincidence.First().Maker = register.Maker;
                        coincidence.First().Model = register.Model;
                        coincidence.First().State = true;
                        await this.UpdateVehicleRegister(coincidence.First());
                    }
                }

                //Buscar los que estan actulmente en bd pero no en el excel
                foreach( VehicleRegister actualRegister in actualRegisters)
                {
                    var coincidence = vehicleRegisters.Where(x => x.Matricule == actualRegister.Matricule).ToList();
                    if (coincidence.Count() == 0)
                    {
                        actualRegister.State = false;
                        await this.UpdateVehicleRegister(actualRegister);
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        private void ValueValidation(VehicleRegister vehicleRegister)
        {
            vehicleRegister.Value = 200000;
            vehicleRegister.DateInsertion = DateTime.UtcNow;

            if (vehicleRegister.DateInsertion.Day % 2 == 0)
                vehicleRegister.Value *= 1.05;

            if (vehicleRegister.Model <= 1997)
                vehicleRegister.Value *= 1.20;
        }
    }
}
