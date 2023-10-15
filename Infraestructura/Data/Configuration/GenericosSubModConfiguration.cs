using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.Data.Configuration
{
    public class GenericosSubModConfiguration : IEntityTypeConfiguration<GenericosvsSubModulos>
    {
        public void Configure(EntityTypeBuilder<GenericosvsSubModulos> builder)
        {
            builder.ToTable("GenericosvsSubModulos");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(w => w.FechaCreacion)
            .HasColumnType("DateTime");
            builder.Property(w => w.FechaModificacion)
            .HasColumnType("DateTime");

            builder.HasOne(p => p.permisosGenericos)
            .WithMany(P => P.GenericosvsSubModulos)
            .HasForeignKey(p => p.IdPermisosFk);

            builder.HasOne(p => p.MaestrosvsSub)
            .WithMany(p => p.GenericosvsSubModulos)
            .HasForeignKey(p => p.IdSubModulos);

            builder.HasOne(p => p.Roles)
            .WithMany(p => p.GenericosvsSubModulos)
            .HasForeignKey(p => p.IdRolFk);
        }
    }
}