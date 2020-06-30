using AutoMapper;
using McqueenDoctor.Core.DTOs;
using McqueenDoctor.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace McqueenDoctor.Infrastructure.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            //Convierte la entidad al Dto y viceversa para evitar conflictos con las relaciones
            CreateMap<VehicleRegister, VehicleRegisterDto>();
            CreateMap<VehicleRegisterDto, VehicleRegister>();

            CreateMap<UserInfo, UserInfoDto>();
            CreateMap<UserInfoDto, UserInfo>();
        }
    }
}
