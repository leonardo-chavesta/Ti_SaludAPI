using Application.Dtos.TipoEmpleados;
using Application.Services.Abstractions;
using Azure;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoEmpleadoController : Controller
    {
        private readonly ITipoEmpleadoService _tipoEmpleadoService;

        public TipoEmpleadoController(ITipoEmpleadoService tipoEmpleadoService)
        {
            _tipoEmpleadoService = tipoEmpleadoService;
        }

        [HttpGet]
        public async Task<IEnumerable<TipoEmpleadoDto>> Get()
            => await _tipoEmpleadoService.ListaEmpleado();

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TipoEmpleadoDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<NotFound, Ok<TipoEmpleadoDto>>>Get (int id)
        {
            var response = await _tipoEmpleadoService.Buscar(id);
            if ( response == null) return TypedResults.NotFound();
            
            return TypedResults.Ok(response);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TipoEmpleadoDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<Results<BadRequest, Ok<TipoEmpleadoDto>>> Post([FromBody]TipoEmpleadoFormDto request)
        {
            var response = await _tipoEmpleadoService.CrearTipoEmpleado(request);
            if (response == null) return TypedResults.BadRequest();

            return TypedResults.Ok(response);

        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TipoEmpleadoDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<Results<BadRequest, NotFound, Ok <TipoEmpleadoDto>>> Put(int id, [FromBody]TipoEmpleadoFormDto request)
        {
            var response = await _tipoEmpleadoService.EditTipoEmpleado(id, request);
            if (response == null) return TypedResults.NotFound();

            return TypedResults.Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TipoEmpleadoDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<NotFound, Ok<TipoEmpleadoDto>>> Delete(int id)
        {
            var response = await _tipoEmpleadoService.ActivarODesactivar(id);

            if (response == null) return TypedResults.NotFound();

            return TypedResults.Ok(response);
        }
    }
}
