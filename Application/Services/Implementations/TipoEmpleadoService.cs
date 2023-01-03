using Application.Dtos.TipoEmpleados;
using Application.Services.Abstractions;
using AutoMapper;
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

        public async Task<IList<TipoEmpleadoDto>> ListaEmpleado()
        {
            var response = await _tipoEmpleadoRepository.ListaEmpleado();

            return _mapper.Map<IList<TipoEmpleadoDto>>(response);
        }
    }
}
