using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repositories.Abstracions
{
    public interface IServicioRepository
    {
        Task<IList<Servicio>> ListarServicio();
        Task<Servicio> CrearServicio(Servicio entity);
        Task<Servicio?> EditarServicio(int id, Servicio entity);
        Task<Servicio?> ActivarXDesactivar(int id);
        Task<Servicio?> Buscar(int id); 

    }
}
