using AutoMapper;
using Brive.Core.DTOs.SucursalADTOs;
using Brive.Core.Entities;
using Brive.Core.Interfaces.IServices;
using Brive.Core.QueryFilter;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Brive.Api.Controllers
{
    [Route("api/{controller}")]
    [ApiController]
    public class SucursalAController: ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISucursalAService _sucursalAService;

        public SucursalAController(IMapper mapper, ISucursalAService sucursalAService)
        {
            _mapper = mapper;
            _sucursalAService = sucursalAService;
        }

        [HttpGet]
        [Route("GetProductsSucursalA")]
        public async Task<ActionResult<List<SucursalADTO>>> Get([FromQuery] SucursalQueryFilter filter)
        {
            var sucursalA = await _sucursalAService.GetAllSucursalA(filter);
            var sucursalADTO = _mapper.Map<List<SucursalADTO>>(sucursalA); 
            return Ok(sucursalADTO);
        }

        [HttpGet("{id}", Name = "GetSucursalById")]
        [Route("GetUniqueProductSucursalA")]
        public async Task<ActionResult<SucursalADTO>> GetById(int id)
        {
            string code = "100010";
            var existingSucursal = await _sucursalAService.GetSucursalAByCode(code);

            if (existingSucursal == null)
                return NotFound();

            var sucursalDTO = _mapper.Map<SucursalADTO>(existingSucursal);
            return Ok(sucursalDTO);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PostSucursalADTO model)
        {
            var entitySucursalA = _mapper.Map<SucursalA>(model);
            await _sucursalAService.AddSucursalA(entitySucursalA);
            return new CreatedAtRouteResult("GetSucursalById", new { id = entitySucursalA.Code}, model);
        }

        [HttpPost]
        [Route("UpdateProductSucursalA")]
        public async Task<ActionResult> Put([FromBody] PutSucursalADTO model)
        {
            var entitySucursalA = _mapper.Map<SucursalA>(model);            
            await _sucursalAService.UpdateSucursalA(entitySucursalA);
            return Ok(true);
        }

        [HttpDelete]
        [Route("ComprarProductSucursalA")]
        public async Task<ActionResult> Delete([FromBody] DeleteSucursalADTO model)
        {
            var entitySucursalA = _mapper.Map<SucursalA>(model);
            await _sucursalAService.RemoveSucursalA(entitySucursalA);
            return Ok(true);
        }
    }
}
