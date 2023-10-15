using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.Data.Configuration
{
    public class ModuloNotificacionesConfiguration : IEntityTypeConfiguration<ModuloNoficaciones>
    {
        public void Configure(EntityTypeBuilder<ModuloNoficaciones> builder)
        {
            builder.ToTable("ModuloNoficaciones");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(w => w.FechaCreacion)
            .HasColumnType("DateTime");
            builder.Property(w => w.FechaModificacion)
            .HasColumnType("DateTime");

            builder.Property(p => p.AsuntoNotificacion)
            .IsRequired()
            .HasMaxLength(80);

            builder.Property(p => p.TextoNotificacion)
            .HasMaxLength(2000);

            builder.HasOne(j => j.TipoNotificacion)
            .WithMany(j => j.ModuloNoficaciones)
            .HasForeignKey(j => j.IdNotificacionFk);

            builder.HasOne(s => s.Radicado)
            .WithMany(s => s.ModuloNoficaciones)
            .HasForeignKey(s => s.IdRadicadoFk);

            builder.HasOne(n => n.EstadoNot)
            .WithMany(n => n.ModuloNoficaciones)
            .HasForeignKey(n => n.IdEstadoNotificacionFk);

            builder.HasOne(m => m.HiloRespuestaNots)
            .WithMany(m => m.ModuloNoficaciones)
            .HasForeignKey( m => m.IdHiloRespuestaFk);

            builder.HasOne(a => a.Formatos)
            .WithMany(a => a.ModuloNoficaciones)
            .HasForeignKey(a => a.IdFormatoFk);

            builder.HasOne(u => u.Requerimientos)
            .WithMany(u => u.ModuloNoficaciones)
            .HasForeignKey(u => u.IdRequerimiento);

        }
    }
}