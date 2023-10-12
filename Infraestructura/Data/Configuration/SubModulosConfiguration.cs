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
            throw new NotImplementedException();
        }
    }
}