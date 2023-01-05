using Application.Dtos.Empleados;
using Application.Services.Abstractions;
using Domain;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Utils;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : Controller
    {
        private readonly IEmpleadoService _empleadoService;

        public EmpleadoController(IEmpleadoService empleadoService)
        {
            _empleadoService = empleadoService;
        }

        [HttpGet]
        public async Task<IEnumerable<EmpleadoDto>> Get()
            => await _empleadoService.ListaEmpleado();


        [HttpPost("Listar/Cabecera")]
        public async Task<IList<EmpleadoDto>> ListarAsync(PeticionFiltroDto<EmpleadoPeticionDto> peticion)
        {
            var operacion = await _empleadoService.ListarAsync(peticion);
            return operacion;
        }
        [HttpGet("ObtenerPorId/{id}")]
        public async Task<Results<NotFound, Ok<EmpleadoDto>>> Get(int id)
        {
            var response = await _empleadoService.Buscar(id);
            if (response == null) return TypedResults.NotFound();

            return TypedResults.Ok(response);
        }
        [HttpPost("Crear")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EmpleadoDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<Results<BadRequest, Ok<EmpleadoDto>>> Post([FromBody]EmpleadoFormDto request)
        {
            var response = await _empleadoService.CrearEmpleado(request);
            if(response == null) return TypedResults.BadRequest();

            return TypedResults.Ok(response);
        }
        [HttpPut("Editar/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EmpleadoDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<Results<BadRequest, NotFound,Ok<EmpleadoDto>>> Put(int id , [FromBody] EmpleadoFormDto request)
        {
            var response = await _empleadoService.EditEmpleado(id, request);

            if (response == null) return TypedResults.BadRequest();

            return TypedResults.Ok(response);
        }
        [HttpDelete("Eliminar/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EmpleadoDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<NotFound, Ok<EmpleadoDto>>> Delete(int id)
        {
            var response = await _empleadoService.ActivarODesactivar(id);
            if (response == null) return TypedResults.NotFound();

            return TypedResults.Ok(response);
        }

    }
}
