using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repositories.Abstracions
{
    public interface ITipoEmpleadoRepository
    {
        Task<IList<TipoEmpleado>> ListaEmpleado();
        Task<TipoEmpleado> CrearTipoEmpleado(TipoEmpleado entity);
        Task<TipoEmpleado?> EditTipoEmpleado(int id , TipoEmpleado entity);
        Task<TipoEmpleado?> ActivarODesactivar(int id);
        Task<TipoEmpleado?> Buscar(int id);
    }
}
