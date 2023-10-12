using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.Data.Configuration
{
    public class RolvsMaestroConfiguration : IEntityTypeConfiguration<RolvsMaestro>
    {
        public void Configure(EntityTypeBuilder<RolvsMaestro> builder)
        {
            builder.ToTable("RolVsMaestro");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.HasOne(o => o.Roles)
            .WithMany(o => o.RolvsMaestros)
            .HasForeignKey(o => o.IdRolFk);

            builder.HasOne(b => b.Maestros)
            .WithMany(b => b.RolvsMaestros)
            .HasForeignKey(b => b.IdMaestros);
        }
    }
}