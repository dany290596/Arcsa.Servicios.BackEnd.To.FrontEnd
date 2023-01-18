using AutoMapper;
using Evaluacion.Domain.Entities.Cv;
using Evaluacion.Services.Interfaces.Cv;
using Evaluacion.Services.Responses;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Evaluacion.Api.Controllers.Cv
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "Cv")]

    public class InformacionController : ControllerBase
    {
        private readonly IInformacionService _informacionService;
        private readonly IMapper _mapper;

        public InformacionController(
            IInformacionService informacionService,
            IMapper mapper
            )
        {
            _informacionService = informacionService;
            _mapper = mapper;
        }

        [Route("Crear")]
        [HttpPost]
        public async Task<IActionResult> Create(Models.Request.Cv.InformacionDTO data)
        {
            var informacion = _mapper.Map<Informacion>(data);
            await _informacionService.Create(informacion);
            Models.Response.Cv.InformacionDTO informacionDTO = _mapper.Map<Models.Response.Cv.InformacionDTO>(informacion);
            var response = new ApiResponse<Models.Response.Cv.InformacionDTO>(true, "La consulta se realizó con éxito", 200, informacionDTO);

            return StatusCode(200, response);
        }

        [Route("Activar")]
        [HttpPatch]
        public async Task<IActionResult> Activate([Required] Guid id)
        {
            var result = await _informacionService.Activate(id);
            var response = new ApiResponse<bool>(true, "La consulta se realizó con éxito", 200, result);

            return StatusCode(200, response);
        }

        [Route("Reactivar")]
        [HttpPatch]
        public async Task<IActionResult> Inactivate([Required] Guid id)
        {
            var result = await _informacionService.Inactivate(id);
            var response = new ApiResponse<bool>(true, "La consulta se realizó con éxito", 200, result);

            return StatusCode(200, response);
        }

        [Route("Actualizar")]
        [HttpPut]
        public async Task<IActionResult> Update([Required] Guid id, Models.Request.Cv.InformacionDTO dTO)
        {
            var informacion = _mapper.Map<Informacion>(dTO);
            informacion.Id = id;

            var result = await _informacionService.Update(informacion);

            var response = new ApiResponse<bool>(true, "La consulta se realizó con éxito", 200, result);

            return StatusCode(200, response);
        }

        [Route("Informacion")]
        [HttpGet]
        public async Task<IActionResult> GetByInformationId(Guid informacionId)
        {
            var informacion = _informacionService.GetByInformationId(informacionId);
            var response = new ApiResponse<Informacion>(true, "La consulta se realizó con éxito", 200, informacion);

            return StatusCode(200, response);
        }

        [Route("Informaciones")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var informacion = _informacionService.GetAll();
            var informacionDTO = _mapper.Map<IEnumerable<Models.Response.Cv.InformacionDTO>>(informacion);

            var response = new ApiResponse<IEnumerable<Models.Response.Cv.InformacionDTO>>(true, "La consulta se realizó con éxito", 200, informacionDTO);

            return StatusCode(200, response);
        }
    }
}