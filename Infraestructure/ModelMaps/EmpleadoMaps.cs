using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.ModelMaps
{
    public class EmpleadoMaps : IEntityTypeConfiguration<Empleado>
    {
        public void Configure(EntityTypeBuilder<Empleado> builder)
        {
            builder.ToTable("EMPLEADO");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("EMPLEADO_ID");
            builder.Property(x => x.Nombre).HasColumnName("NOMBRE");
            builder.Property(x => x.Apellido).HasColumnName("APELLIDO");
            builder.Property(x => x.Direccion).HasColumnName("DIRECCION");
            builder.Property(x => x.FechaNacimiento).HasColumnName("FECHA_NACIMIENTO");
            builder.Property(x => x.Documento).HasColumnName("DOCUMENTO");
            builder.Property(x => x.TipoEmpleadoId).HasColumnName("TIPO_EMPLEADO_ID");
            builder.Property(x => x.Estado).HasColumnName("ESTADO");

            builder.HasOne(t => t.TipoEmpleado).WithMany(t => t.Empleados).HasForeignKey(t => t.TipoEmpleadoId);
        }
    }
}
