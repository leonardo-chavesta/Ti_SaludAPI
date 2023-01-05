using Application.Dtos.Servicios;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Abstractions
{
    public interface IServicioService
    {
        Task<IList<ServicioDto>> ListarServico();
        Task<ServicioDto> CrearServicio(ServicioFormDto entity);
        Task<ServicioDto> EditarServicio(int id, ServicioFormDto entity);
        Task<ServicioDto> BuscarServicioXId(int id);
        Task<ServicioDto> ActivarXDesactivar(int id);
    }
}
