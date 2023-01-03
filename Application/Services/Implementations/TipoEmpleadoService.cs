using Application.Dtos.TipoEmpleados;
using Application.Services.Abstractions;
using AutoMapper;
using Domain;
using Infraestructure.Repositories.Abstracions;

namespace Application.Services.Implementations
{
    public class TipoEmpleadoService : ITipoEmpleadoService
    {
        private readonly IMapper _mapper;
        private readonly ITipoEmpleadoRepository _tipoEmpleadoRepository;

        public TipoEmpleadoService(IMapper mapper, ITipoEmpleadoRepository tipoEmpleadoRepository)
        {
            _mapper = mapper;
            _tipoEmpleadoRepository= tipoEmpleadoRepository;
        }

        public async Task<TipoEmpleadoDto> CrearTipoEmpleado(TipoEmpleadoFormDto entity)
        {
            var dto = _mapper.Map<TipoEmpleado>(entity);

            var response = await _tipoEmpleadoRepository.CrearTipoEmpleado(dto);

            return _mapper.Map<TipoEmpleadoDto>(response);
        }

        public async Task<TipoEmpleadoDto?> EditTipoEmpleado(int id, TipoEmpleadoFormDto entity)
        {
            var dto = _mapper.Map<TipoEmpleado>(entity);

            var response = await _tipoEmpleadoRepository.EditTipoEmpleado(id, dto);
            
            return _mapper.Map<TipoEmpleadoDto>(response);
        }

        public async Task<TipoEmpleadoDto?> ActivarODesactivar(int id)
        {
            var response = await _tipoEmpleadoRepository.ActivarODesactivar(id);

            return _mapper.Map<TipoEmpleadoDto>(response);
        }

        public async Task<TipoEmpleadoDto?> Buscar(int id)
        {
            var response = await _tipoEmpleadoRepository.Buscar(id);

            return _mapper.Map<TipoEmpleadoDto>(response);
        }

        public async Task<IList<TipoEmpleadoDto>> ListaEmpleado()
        {
            var response = await _tipoEmpleadoRepository.ListaEmpleado();

            return _mapper.Map<IList<TipoEmpleadoDto>>(response);
        }
    }
}
