using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.Data.Configuration
{
    public class HiloRespuestaConfiguration : IEntityTypeConfiguration<HiloRespuestaNot>
    {
        public void Configure(EntityTypeBuilder<HiloRespuestaNot> builder)
        {
            builder.ToTable("HiloRespuestaNotificacion");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(p =>p.NombreTipo)
            .IsRequired()
            .HasMaxLength(80);
        }
    }
}