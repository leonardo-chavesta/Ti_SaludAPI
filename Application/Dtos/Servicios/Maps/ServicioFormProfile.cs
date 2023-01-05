using AutoMapper;
using Domain;

namespace Application.Dtos.Servicios.Maps
{
    public class ServicioFormProfile : Profile
    {
        public ServicioFormProfile() 
        {
            CreateMap<Servicio, ServicioFormDto>().ReverseMap();
        }
    }
}
