using Application.Dtos.Empleados;
using Application.Dtos.Servicios;
using Application.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicioController : ControllerBase
    {

        private readonly IServicioService _servicioService;

        public ServicioController(IServicioService servicioService) 
        {
            _servicioService= servicioService;
        }

        [HttpGet("Listar")]
        public async Task<IEnumerable<ServicioDto>> Get()
        {
            var response = await _servicioService.ListarServico();
            return response;
        }
        [HttpGet("Buscar/{id}")]
        public async Task<Results<NotFound, Ok<ServicioDto>>> Get(int id)
        {
            var response = await _servicioService.BuscarServicioXId(id);

            if (response == null) return TypedResults.NotFound();

            return TypedResults.Ok(response);
        }


        [HttpPost("Crear")]
        [ProducesResponseType(StatusCodes.Status200OK, Type= typeof(ServicioDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<Results<BadRequest, Ok<ServicioDto>>> Post([FromBody] ServicioFormDto request)
        {
            var dto = await _servicioService.CrearServicio(request);
            if (dto == null) return TypedResults.BadRequest();

            return TypedResults.Ok(dto);
        }
        [HttpPut("Editar/{id}")]
        public async Task<Results<NotFound, Ok<ServicioDto>>> Put(int id, [FromBody] ServicioFormDto request)
        {
            var response = await _servicioService.EditarServicio(id, request);

            if (response == null) return TypedResults.NotFound();
            return TypedResults.Ok(response);
        }

        [HttpDelete("ELiminar/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EmpleadoDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<NotFound, Ok<ServicioDto>>> Delete(int id)
        {
            var response = await _servicioService.ActivarXDesactivar(id);

            if(response == null) return TypedResults.NotFound();
            return TypedResults.Ok(response);   
        }
        

    }
}
