using AutoMapper;
using McqueenDoctor.API.Responses;
using McqueenDoctor.Core.DTOs;
using McqueenDoctor.Core.Entities;
using McqueenDoctor.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace McqueenDoctor.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserInfoController : ControllerBase
    {
        private readonly IUserInfoService UserInfoService;
        private readonly IMapper Mapper;

        public UserInfoController(IUserInfoService userInfoService, IMapper mapper)
        {
            UserInfoService = userInfoService;
            Mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsersInfo()
        {
            var usersInfo = await UserInfoService.GetUsersInfo();        //Obtengo los registros de vehiculos
            var usersInfoDTO = Mapper.Map<IEnumerable<UserInfoDto>>(usersInfo);        //Los convierto a DTO
            var response = new ApiResponse<IEnumerable<UserInfoDto>>(usersInfoDTO);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> PostUserInfo(UserInfoDto userInfoDto)
        {
            var userInfo = Mapper.Map<UserInfo>(userInfoDto);

            await UserInfoService.InsertUserInfo(userInfo);

            userInfoDto = Mapper.Map<UserInfoDto>(userInfo);
            var resultado = new ApiResponse<UserInfoDto>(userInfoDto);
            return Ok(resultado);
        }
    }
}
