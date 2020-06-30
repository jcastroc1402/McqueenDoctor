using AutoMapper;
using McqueenDoctor.API.Responses;
using McqueenDoctor.API.Models;
using McqueenDoctor.Core.DTOs;
using McqueenDoctor.Core.Entities;
using McqueenDoctor.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ExcelDataReader;

namespace McqueenDoctor.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehicleRegisterController : ControllerBase
    {
        private readonly IVehicleRegisterService VehicleRegisterService;
        private readonly IMapper Mapper;
        private readonly IHostEnvironment HostEnvironment;

        public VehicleRegisterController(IVehicleRegisterService vehicleRegisterService, IMapper mapper, IHostEnvironment hostEnvironment)
        {
            VehicleRegisterService = vehicleRegisterService;
            Mapper = mapper;
            HostEnvironment = hostEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> GetVehicleRegisters()
        {
            var vehicleRegisters = await VehicleRegisterService.GetVehicleRegisters();        //Obtengo los registros de vehiculos
            var vehicleRegistersDTO = Mapper.Map<IEnumerable<VehicleRegisterDto>>(vehicleRegisters);        //Los convierto a DTO
            var response = new ApiResponse<IEnumerable<VehicleRegisterDto>>(vehicleRegistersDTO);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicleRegister(int id)
        {
            var vehicleRegister = await VehicleRegisterService.GetVehicleRegister(id);
            var vehicleRegisterDTO = Mapper.Map<VehicleRegisterDto>(vehicleRegister);
            var response = new ApiResponse<VehicleRegisterDto>(vehicleRegisterDTO);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> PostVehicleRegister(VehicleRegisterDto vehicleRegisterDto)
        {
            var vehicleRegister = Mapper.Map<VehicleRegister>(vehicleRegisterDto);

            var result = await VehicleRegisterService.InsertVehicleRegister(vehicleRegister);
            object response;

            if (!result)
            {
                response = new
                {
                    response = "No se ha agregado el vehiculo"
                };

                return Ok(response);
            }

            vehicleRegisterDto = Mapper.Map<VehicleRegisterDto>(vehicleRegister);
            response = new ApiResponse<VehicleRegisterDto>(vehicleRegisterDto);
            return Ok(response);
        }

        [HttpPost]
        [Route("ExcelFile")]
        public async Task<IActionResult> PostExcelRegisters([FromForm] FileUpload fileObj, [FromForm] int id)
        {
            string filename = $"{HostEnvironment.ContentRootPath}\\Files\\{fileObj.file.FileName}";
            using (FileStream fileStream = System.IO.File.Create(filename)) {
                fileObj.file.CopyTo(fileStream);
                fileStream.Flush();
            }

            //Metodo de obtiene los registros del excel
            var registers = this.GetPostVehicleRegister(fileObj.file.FileName, HostEnvironment, id);
            var result = await VehicleRegisterService.UpdateVehicleRegisterExcel(registers);
            object response;

            if (!result)
            {
                response = new
                {
                    response = "Ha ocurrido un error en la operacion"
                };
            }
            else
            {
                response = new
                {
                    response = "Actualizacion satisfactoria"
                };
            }

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> PutVehicleRegister(int id, VehicleRegisterDto vehicleRegisterDto)
        {
            var vehicleRegister = Mapper.Map<VehicleRegister>(vehicleRegisterDto);
            vehicleRegister.Id = id;

            var result = await VehicleRegisterService.UpdateVehicleRegister(vehicleRegister);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicleRegister(int id)
        {
            var result = await VehicleRegisterService.DeleteVehicleRegister(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        private List<VehicleRegister> GetPostVehicleRegister(string fName, IHostEnvironment hostEnvironment, int id)
        {
            List<VehicleRegister> vehicleRegisters = new List<VehicleRegister>();
            var fileName = $"{hostEnvironment.ContentRootPath}\\Files\\{fName}";
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            using (var stream = System.IO.File.Open(fileName, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    while (reader.Read())
                    {
                        vehicleRegisters.Add(new VehicleRegister()
                        {
                            Color = reader.GetValue(0).ToString(),
                            Model = Convert.ToInt32(reader.GetValue(1).ToString()),
                            Maker = reader.GetValue(2).ToString(),
                            Img = "",
                            Matricule = reader.GetValue(3).ToString(),
                            UserInfoId = id
                        });
                    }
                }
            }
            return vehicleRegisters;
        }
    }
}
