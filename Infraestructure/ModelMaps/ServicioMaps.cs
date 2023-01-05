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
    public class ServicioMaps : IEntityTypeConfiguration<Servicio>
    {
        public void Configure(EntityTypeBuilder<Servicio> builder)
        {
            builder.ToTable("SERVICIO");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("SERVICIO_ID");
            builder.Property(x => x.Codigo).HasColumnName("CODIGO");
            builder.Property(x => x.Nombre).HasColumnName("NOMBRE");
            builder.Property(x => x.Estado).HasColumnName("ESTADO");
        }
        
    }
}
