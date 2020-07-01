using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using McqueenDoctor.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using McqueenDoctor.Core.DTOs;
using McqueenDoctor.Core.Entities;
using McqueenDoctor.API.Responses;

namespace McqueenDoctor.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly ISecurityService SecurityService;
        private readonly IMapper Mapper;

        public SecurityController(ISecurityService securityService, IMapper mapper)
        {
            SecurityService = securityService;
            Mapper = mapper;
        }

        //registro de usuario
        [HttpPost]
        public async Task<IActionResult> PostSecurity(SecurityDto securityDto)
        {
            var security = Mapper.Map<Security>(securityDto);

            await SecurityService.RegisterUser(security);

            securityDto = Mapper.Map<SecurityDto>(security);
            var response = new ApiResponse<SecurityDto>(securityDto);
            return Ok(response);
        }
    }
}