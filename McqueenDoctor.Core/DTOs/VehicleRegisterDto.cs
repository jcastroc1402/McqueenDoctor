using System;
using System.Collections.Generic;
using System.Text;

namespace McqueenDoctor.Core.DTOs
{
    public class VehicleRegisterDto
    {
        public string Color { get; set; }
        public int Model { get; set; }
        public string Maker { get; set; }
        public string Matricule { get; set; }
        public string Img { get; set; }
        public bool State { get; set; }
        public DateTime DateInsertion { get; set; }
        public double Value { get; set; }
        public int UserInfoId { get; set; }
    }
}
