using McqueenDoctor.Core.Entities;
using McqueenDoctor.Core.Interfaces;
using McqueenDoctor.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McqueenDoctor.Infrastructure.Repositories
{
    public class VehicleRegisterRepository : BaseRepository<VehicleRegister>, IVehicleRegisterRepository
    {
        public VehicleRegisterRepository(ApplicationDbContext context) : base(context)
        {
            //Envio el contexto a BaseRepository
        }

        public async Task<IEnumerable<VehicleRegister>> GetVehicleRegistersByUser(int userId)
        {
            return await Entities.Where(x => x.Id == userId).ToListAsync();     //Utilizar expresion de Linq, pendiente repaso
        }
    }
}
