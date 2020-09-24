using AutoMapper;
using Brive.Core.DTOs;
using Brive.Core.Entities;
using Brive.Core.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Brive.Api.Controllers
{
    [Route("api/{controller}")]
    [ApiController]
    public class SucursalController : ControllerBase
    {
        private readonly ISucursalAService _sucursalAService;
        private readonly ISucursalBService _sucursalBService;
        private readonly IMapper _mapper;

        public SucursalController(ISucursalAService sucursalAService, ISucursalBService sucursalBService, IMapper mapper)
        {
            _sucursalAService = sucursalAService;
            _sucursalBService = sucursalBService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("AddProduct")]
        public async Task<ActionResult> Post([FromBody] PostSucursalGenericDTO model)
        {
            var sucursalA = _mapper.Map<SucursalA>(model);
            var sucursalB = _mapper.Map<SucursalB>(model);
            await _sucursalAService.AddSucursalA(sucursalA);
            await _sucursalBService.AddSucursalB(sucursalB);

            return Ok(true);
        }
    }
}
