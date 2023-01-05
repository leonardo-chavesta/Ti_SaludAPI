using Application.Dtos.TipoEmpleados;

namespace Application.Dtos.Empleados
{
    public class EmpleadoDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Documento { get; set; }
        public int TipoEmpleadoId { get; set; }
        public int Estado { get; set; }

        public TipoEmpleadoDto TipoEmpleado { get; set; }
    }
}
