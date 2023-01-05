using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repositories.Abstracions
{
    public interface IEmpleadoRepository
    {
        Task<IList<Empleado>> ListaEmpleado();
        Task<Empleado> CrearEmpleado(Empleado entity);
        Task<Empleado?> EditEmpleado(int id, Empleado entity);
        Task<Empleado?> ActivarODesactivar(int id);
        Task<Empleado?> Buscar(int id);


        Task<IList<Empleado>> ListarAsync(string nombre,string apellido,string tipoEmpleado);
    }
}
