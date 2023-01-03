using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.TipoEmpleados.Maps
{
    public class TipoEmpleadoFormProfile : Profile
    {
        public TipoEmpleadoFormProfile()
        {
            CreateMap<TipoEmpleado, TipoEmpleadoFormDto>().ReverseMap();
        }
    }
}
