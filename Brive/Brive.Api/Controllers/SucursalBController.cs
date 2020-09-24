using AutoMapper;
using Brive.Core.DTOs.SucursalBDTOs;
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
    public class SucursalBController: ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISucursalBService _sucursalBService;

        public SucursalBController(IMapper mapper, ISucursalBService sucursalBService)
        {
            _mapper = mapper;
            _sucursalBService = sucursalBService;
        }

        [HttpGet]
        [Route("GetProductsSucursalB")]
        public async Task<ActionResult<List<SucursalBDTO>>> Get([FromQuery] SucursalQueryFilter filter)
        {
            var sucursalB = await _sucursalBService.GetAllSucursalB(filter);
            var sucursalBDTO = _mapper.Map<List<SucursalBDTO>>(sucursalB); 
            return Ok(sucursalBDTO);
        }

        [HttpGet("{id}", Name = "GetSucursalById")]
        public async Task<ActionResult<SucursalBDTO>> GetById(int id)
        {
            var existingSucursal = await _sucursalBService.GetSucursalBById(id);

            if (existingSucursal == null)
                return NotFound();

            var sucursalBDTO = _mapper.Map<SucursalBDTO>(existingSucursal);
            return Ok(sucursalBDTO);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PostSucursalBDTO model)
        {
            var entitySucursalB = _mapper.Map<SucursalB>(model);
            await _sucursalBService.AddSucursalB(entitySucursalB);
            return new CreatedAtRouteResult("GetSucursalById", new { id = entitySucursalB.Id }, model);
        }

        [HttpPost]
        [Route("UpdateProductSucursalB")]
        public async Task<ActionResult> Put([FromBody] PutSucursalBDTO model)
        {
            var entitySucursalB = _mapper.Map<SucursalB>(model);            
            await _sucursalBService.UpdateSucursalB(entitySucursalB);
            return Ok(true);
        }

        [HttpDelete]
        [Route("ComprarProductSucursalB")]
        public async Task<ActionResult> Delete([FromBody] DeleteSucursalBDTO model)
        {
            var entitySucursalB = _mapper.Map<SucursalB>(model);
            await _sucursalBService.RemoveSucursalB(entitySucursalB);
            return Ok(true);
        }
    }
}
