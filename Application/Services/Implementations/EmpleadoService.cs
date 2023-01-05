using Application.Dtos.Empleados;
using Application.Services.Abstractions;
using AutoMapper;
using Domain;
using Infraestructure.Repositories.Abstracions;
using Utils;

namespace Application.Services.Implementations
{
    public class EmpleadoService : IEmpleadoService
    {
        private readonly IMapper _mapper;
        private readonly IEmpleadoRepository _empleadoRepository;

        public EmpleadoService(IMapper mapper, IEmpleadoRepository empleadoRepository)
        {
            _mapper = mapper;
            _empleadoRepository = empleadoRepository;
        }

        public async Task<EmpleadoDto?> ActivarODesactivar(int id)
        {
            var response = await _empleadoRepository.ActivarODesactivar(id);

            return _mapper.Map<EmpleadoDto>(response);
        }

        public async Task<EmpleadoDto?> Buscar(int id)
        {
            var response = await _empleadoRepository.Buscar(id);

            return _mapper.Map<EmpleadoDto>(response);
        }

        public async Task<EmpleadoDto> CrearEmpleado(EmpleadoFormDto entity)
        {
            var dto = _mapper.Map<Empleado>(entity);
            var response = await _empleadoRepository.CrearEmpleado(dto);
            return _mapper.Map<EmpleadoDto>(response);

        }

        public async Task<EmpleadoDto?> EditEmpleado(int id, EmpleadoFormDto entity)
        {
            var dto = _mapper.Map<Empleado>(entity);

            var response = await _empleadoRepository.EditEmpleado(id,dto);

            return _mapper.Map<EmpleadoDto>(response);
        }

        public async Task<IList<EmpleadoDto>> ListaEmpleado()
        {
            var response = await _empleadoRepository.ListaEmpleado();
            return _mapper.Map<IList<EmpleadoDto>>(response);
        }


        public async Task<IList<EmpleadoDto>> ListarAsync(PeticionFiltroDto<EmpleadoPeticionDto> peticion)
        {
            var entidad = await _empleadoRepository.ListarAsync(peticion.Filtro.Nombre,peticion.Filtro.Apellido ,peticion.Filtro.TipoEmpleado);
            return _mapper.Map<IList<EmpleadoDto>>(entidad);
        }
    }
}
