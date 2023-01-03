using Application.Dtos.TipoEmpleados;

namespace Application.Services.Abstractions
{
    public interface ITipoEmpleadoService
    {
        Task<IList<TipoEmpleadoDto>> ListaEmpleado();
    }
}
