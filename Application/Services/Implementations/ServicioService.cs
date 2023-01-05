using Application.Dtos.Servicios;
using Application.Services.Abstractions;
using AutoMapper;
using Domain;
using Infraestructure.Repositories.Abstracions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Implementations
{
    public class ServicioService : IServicioService
    {
        private readonly IMapper _mapper;
        private readonly IServicioRepository _servicioRepository;
        public ServicioService(IMapper mapper, IServicioRepository servicioRepository) 
        {
            _mapper= mapper;
            _servicioRepository= servicioRepository;
        }

        public async Task<ServicioDto> ActivarXDesactivar(int id)
        {
            var response = await _servicioRepository.ActivarXDesactivar(id);

            return _mapper.Map<ServicioDto>(response);
        }

        public async Task<ServicioDto> BuscarServicioXId(int id)
        {
            var response = await _servicioRepository.Buscar(id);

            return _mapper.Map<ServicioDto>(response);
        }

        public async Task<ServicioDto> CrearServicio(ServicioFormDto entity)
        {
            var dto = _mapper.Map<Servicio>(entity);
            var response = await _servicioRepository.CrearServicio(dto);

            return _mapper.Map<ServicioDto>(response);
        }

        public async Task<ServicioDto> EditarServicio(int id, ServicioFormDto entity)
        {
            var dto = _mapper.Map<Servicio>(entity);
            var response = await _servicioRepository.EditarServicio(id, dto);

            return _mapper.Map<ServicioDto>(response);
        }

        public async Task<IList<ServicioDto>> ListarServico()
        {
            var response = await _servicioRepository.ListarServicio();

            return _mapper.Map<IList<ServicioDto>>(response);
        }
    }
}
