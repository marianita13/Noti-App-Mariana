using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.Data.Configuration
{
    public class PermisosGenericosConfiguration : IEntityTypeConfiguration<PermisosGenericos>
    {
        public void Configure(EntityTypeBuilder<PermisosGenericos> builder)
        {
            builder.ToTable("PermisosGenericos");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(w => w.FechaCreacion)
            .HasColumnType("DateTime");
            builder.Property(w => w.FechaModificacion)
            .HasColumnType("DateTime");

            builder.Property(p => p.NombrePermiso)
            .IsRequired()
            .HasMaxLength(50);
        }
    }
}