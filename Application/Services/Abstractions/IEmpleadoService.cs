using Application.Dtos.Empleados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Application.Services.Abstractions
{
    public interface IEmpleadoService
    {
        
        Task<EmpleadoDto> CrearEmpleado(EmpleadoFormDto entity);
        Task<EmpleadoDto?> EditEmpleado(int id, EmpleadoFormDto entity);
        Task<EmpleadoDto?> ActivarODesactivar(int id);
        Task<EmpleadoDto?> Buscar(int id);
        Task<IList<EmpleadoDto>> ListaEmpleado();

        Task<IList<EmpleadoDto>> ListarAsync(PeticionFiltroDto<EmpleadoPeticionDto> peticion);


    }
}
