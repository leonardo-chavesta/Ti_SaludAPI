using Application.Dtos.TipoEmpleados;
using Domain;

namespace Application.Services.Abstractions
{
    public interface ITipoEmpleadoService
    {
        Task<TipoEmpleadoDto> CrearTipoEmpleado(TipoEmpleadoFormDto entity);
        Task<TipoEmpleadoDto?> EditTipoEmpleado(int id, TipoEmpleadoFormDto entity);
        Task<TipoEmpleadoDto?> ActivarODesactivar(int id);
        Task<TipoEmpleadoDto?> Buscar(int id);

        Task<IList<TipoEmpleadoDto>> ListaEmpleado();
    }
}
