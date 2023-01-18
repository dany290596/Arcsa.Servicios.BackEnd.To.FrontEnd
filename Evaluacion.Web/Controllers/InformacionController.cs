using AutoMapper;
using Evaluacion.Domain.Entities.Cv;
using Evaluacion.Services.Interfaces.Cv;
using Evaluacion.Services.Responses;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Evaluacion.Web.Controllers
{
    public class InformacionController : Controller
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

        public IActionResult Index()
        {
            var informacion = _informacionService.GetAll();
            var informacionDTO = _mapper.Map<IEnumerable<Models.Response.Cv.InformacionDTO>>(informacion);

            var response = new ApiResponse<IEnumerable<Models.Response.Cv.InformacionDTO>>(true, "La consulta se realizó con éxito", 200, informacionDTO);

            return View(response);
        }

        public async Task<IActionResult> Create()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<string>(false, "Ocurrió un error", 500, null));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(Models.Request.Cv.InformacionDTO data)
        {
            try
            {
                var informacion = _mapper.Map<Informacion>(data);
                await _informacionService.Create(informacion);
                Models.Response.Cv.InformacionDTO informacionDTO = _mapper.Map<Models.Response.Cv.InformacionDTO>(informacion);
                var response1 = new ApiResponse<Models.Response.Cv.InformacionDTO>(true, "La consulta se realizó con éxito", 200, informacionDTO);

                var informaciones = _informacionService.GetAll();
                var informacionesDTO = _mapper.Map<IEnumerable<Models.Response.Cv.InformacionDTO>>(informaciones);

                var response2 = new ApiResponse<IEnumerable<Models.Response.Cv.InformacionDTO>>(true, "La consulta se realizó con éxito", 200, informacionesDTO);

                return View("Index", response2);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<string>(false, "Ocurrió un error", 500, null));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            try
            {
                var informacion = _informacionService.GetByInformationId(id);
                var informacionesDTO = _mapper.Map<Models.Request.Cv.InformacionDTO>(informacion);

                return View(informacionesDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<string>(false, "Ocurrió un error", 500, null));
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([Required] Guid id, Models.Request.Cv.InformacionDTO data)
        {
            try
            {
                var informacion = _mapper.Map<Informacion>(data);
                informacion.Id = id;
                var result = await _informacionService.Update(informacion);
                var response = new ApiResponse<bool>(true, "La consulta se realizó con éxito", 200, result);

                return Json(new { response });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<string>(false, "Ocurrió un error", 500, null));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Detail(Guid id)
        {
            try
            {
                var informacion = _informacionService.GetByInformationId(id);
                var informacionesDTO = _mapper.Map<Models.Response.Cv.InformacionDTO>(informacion);

                return View(informacionesDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<string>(false, "Ocurrió un error", 500, null));
            }
        }

        [HttpPatch]
        public async Task<IActionResult> Inactivate(Guid id)
        {
            try
            {
                var result = await _informacionService.Inactivate(id);
                var response = new ApiResponse<bool>(true, "Se inactivó correctamente", 200, result);

                return Json(new { response });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<string>(false, "Ocurrió un error", 500, null));
            }
        }

        [HttpPatch]
        public async Task<IActionResult> Activate(Guid id)
        {
            try
            {
                var result = await _informacionService.Activate(id);
                var response = new ApiResponse<bool>(true, "Se activó correctamente", 200, result);

                return Json(new { response });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<string>(false, "Ocurrió un error", 500, null));
            }
        }
    }
}