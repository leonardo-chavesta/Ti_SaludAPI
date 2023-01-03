using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Empleado
    {
        public int Id { get; set; }
        public string Nombre { get; set; } 
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Documento { get; set; }
        public int TipoEmpleadoId { get; set; }
        public int Estado { get; set; } = 1;

        public virtual TipoEmpleado TipoEmpleado { get; set; }
    }
}
