using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Data
{
    public class NotiAppContext : DbContext
    {
        public NotiAppContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Auditoria> Auditorias { get; set; }
        public DbSet<BlockChain> BlockChains { get; set; }
        public DbSet<EstadoNotificacion> EstadoNotificaciones { get; set; }
        public DbSet<Formatos> Formatos { get; set; }
        public DbSet<GenericosvsSubModulos> GenericosvsSubModulos { get; set; }
        public DbSet<HiloRespuestaNot> HiloRespuestaNots { get; set; }
        public DbSet<MaestrosvsSubModulos> MaestrosvsSubModulos { get; set; }
        public DbSet<ModuloNoficaciones> ModuloNoficaciones { get; set; }
        public DbSet<ModulosMaestros> ModulosMaestros { get; set; }
        public DbSet<PermisosGenericos> PermisosGenericos { get; set; }
        public DbSet<Radicados> Radicados { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<RolvsMaestro> RolvsMaestros { get; set; }
        public DbSet<SubModulos> SubModulos { get; set; }
        public DbSet<TipoNotificaciones> TipoNotificaciones { get; set; }
        public DbSet<TipoRequerimiento> TipoRequerimientos { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public async Task<int> SaveAsync(){
            return await base.SaveChangesAsync();
        }
    }
}