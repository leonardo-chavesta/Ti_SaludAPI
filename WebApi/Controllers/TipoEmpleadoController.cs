using Application.Dtos.TipoEmpleados;
using Application.Services.Abstractions;
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
    }
}
