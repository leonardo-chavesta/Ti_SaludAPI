using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class TipoEmpleado
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public int Estado { get; set; } = 1;

        public virtual IList<Empleado> Empleados { get; set;}
    }
}
