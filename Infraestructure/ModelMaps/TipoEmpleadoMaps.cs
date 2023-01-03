using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain;

namespace Infraestructure.ModelMaps
{
    public class TipoEmpleadoMaps : IEntityTypeConfiguration<TipoEmpleado>
    {
        public void Configure(EntityTypeBuilder<TipoEmpleado> builder)
        {
            builder.ToTable("TIPO_EMPLEADO");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("TIPO_EMPLEADO_ID");
            builder.Property(t => t.Codigo).HasColumnName("CODIGO");
            builder.Property(t => t.Nombre).HasColumnName("NOMBRE");
            builder.Property(t => t.Estado).HasColumnName("ESTADO");
        }
    }
}
