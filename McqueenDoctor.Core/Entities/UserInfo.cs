using System;
using System.Collections.Generic;
using System.Text;

namespace McqueenDoctor.Core.Entities
{
    public class UserInfo : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Rol { get; set; }

        //Relacion con Registros
        public List<VehicleRegister> VehicleRegisters { get; set; }
    }
}
