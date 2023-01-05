using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Empleados
{
    public class EmpleadoPeticionDto
    {
        public string Nombre { get; set; }
        public string Apellido { get; set;}
        public string TipoEmpleado { get; set; }
    }
}
