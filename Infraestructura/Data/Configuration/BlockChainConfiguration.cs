using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.Data.Configuration
{
    public class BlockChainConfiguration : IEntityTypeConfiguration<BlockChain>
    {
        public void Configure(EntityTypeBuilder<BlockChain> builder)
        {
            builder.ToTable("BlockChain");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(e => e.HashGenerado)
            .IsRequired()
            .HasMaxLength(100);

            builder.Property(w => w.FechaCreacion)
            .HasColumnType("DateTime");
            builder.Property(w => w.FechaModificacion)
            .HasColumnType("DateTime");

            builder.HasOne(p => p.Auditorias)
            .WithMany(p => p.BlockChains)
            .HasForeignKey(e => e.IdAuditoriaFk);

            builder.HasOne(p => p.HiloRespuestaNots)
            .WithMany(p => p.BlockChains)
            .HasForeignKey(p => p.IdHiloRespuestaFk);

            builder.HasOne(p => p.TipoNots)
            .WithMany(p => p.BlockChains)
            .HasForeignKey(P => P.IdNotificacionFk);
        }
    }
}