using McqueenDoctor.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace McqueenDoctor.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        //Definir propiedades habilitadas a usar por la unidad de trabajo
        IVehicleRegisterRepository VehiculeRegisterRepository { get; }      //Interface especifica de repositorio con metodos adicionales
        IRepository<UserInfo> UserInfoRepository { get; }

        void SaveChanges();

        Task SaveChangesAsync();
    }
}
