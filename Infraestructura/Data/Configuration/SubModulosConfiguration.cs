using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.Data.Configuration
{
    public class SubModulosConfiguration : IEntityTypeConfiguration<SubModulos>
    {
        public void Configure(EntityTypeBuilder<SubModulos> builder)
        {
            builder.ToTable("SubModulos");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(w => w.FechaCreacion)
            .HasColumnType("DateTime");
            builder.Property(w => w.FechaModificacion)
            .HasColumnType("DateTime");

            builder.Property(p => p.NombreSubmodulo)
            .IsRequired()
            .HasMaxLength(80);
        }
    }
}