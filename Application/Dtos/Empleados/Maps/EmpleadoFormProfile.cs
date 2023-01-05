using AutoMapper;
using Domain;

namespace Application.Dtos.Empleados.Maps
{
    public class EmpleadoFormProfile : Profile
    {
        public EmpleadoFormProfile() 
        {
            CreateMap<Empleado, EmpleadoFormProfile>().ReverseMap();
        }
    }
}
