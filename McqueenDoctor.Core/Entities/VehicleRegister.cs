using System;
using System.Collections.Generic;
using System.Text;

namespace McqueenDoctor.Core.Entities
{
    public class VehicleRegister : BaseEntity
    {
        public string Color { get; set; }
        public int Model { get; set; }
        public string Maker { get; set; }
        public string Matricule { get; set; }
        public string Img { get; set; }
        public bool State { get; set; }
        public DateTime DateInsertion { get; set; }
        public double Value { get; set; }

        //Relacion con Registros
        public int UserInfoId { get; set; }
        public UserInfo UserInfo { get; set; }
    }
}
