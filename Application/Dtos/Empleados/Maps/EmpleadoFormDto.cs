using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Empleados.Maps
{
    public class EmpleadoFormDto : Profile
    {
        public EmpleadoFormDto() 
        {
            CreateMap<Empleado, EmpleadoFormDto>().ReverseMap();
        }
    }
}
