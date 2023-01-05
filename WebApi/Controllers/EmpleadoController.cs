using Application.Dtos.Empleados;
using Application.Services.Abstractions;
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

    }
}
