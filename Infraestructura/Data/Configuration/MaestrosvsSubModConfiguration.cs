using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.Data.Configuration
{
    public class MaestrosvsSubModConfiguration : IEntityTypeConfiguration<MaestrosvsSubModulos>
    {
        public void Configure(EntityTypeBuilder<MaestrosvsSubModulos> builder)
        {
            builder.ToTable("MaestrosvsSubModulos");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(w => w.FechaCreacion)
            .HasColumnType("DateTime");
            builder.Property(w => w.FechaModificacion)
            .HasColumnType("DateTime");

            builder.HasOne(e => e.Maestros)
            .WithMany(p => p.MaestrosvsSubModulos)
            .HasForeignKey(p => p.IdMaestro);

            builder.HasOne(p => p.subModulos)
            .WithMany(p => p.MaestrosvsSubModulos)
            .HasForeignKey(P => P.IdSubModulo);

        }
    }
}