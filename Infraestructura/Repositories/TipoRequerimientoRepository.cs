using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infraestructura.Data;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Repositories
{
    public class TipoRequerimientoRepository : GenericRepository<TipoRequerimiento>, ITipoRequerimiento
    {
        private readonly NotiAppContext _context;
        public TipoRequerimientoRepository(NotiAppContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<TipoRequerimiento>> GetAllAsync(){
            return await _context.TipoRequerimientos
            .Include(m => m.ModuloNoficaciones)
            .ToListAsync();
        }

        public async Task<List<ModuloNoficaciones>> GetModuloNotificaciones(int Id){
            return await _context.ModuloNoficaciones.Where(p => p.IdRequerimiento == Id).ToListAsync();
        }

        public async Task<TipoRequerimiento> GetIdAsync(int id){
            return await _context.TipoRequerimientos
            .Include(m => m.ModuloNoficaciones)
            .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}