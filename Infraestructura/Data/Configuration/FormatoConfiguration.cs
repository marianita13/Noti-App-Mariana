using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.Data.Configuration
{
    public class FormatoConfiguration : IEntityTypeConfiguration<Formatos>
    {
        public void Configure(EntityTypeBuilder<Formatos> builder)
        {
            builder.ToTable("Formatos");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(w => w.FechaCreacion)
            .HasColumnType("DateTime");
            builder.Property(w => w.FechaModificacion)
            .HasColumnType("DateTime");

            builder.Property(p => p.NombreFormato)
            .IsRequired()
            .HasMaxLength(50);
        }
    }
}