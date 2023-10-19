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
    public class TipoNotificacionesRepository : GenericRepository<TipoNotificaciones>, ITipoNotificaciones
    {
        private readonly NotiAppContext _context;
        public TipoNotificacionesRepository(NotiAppContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<TipoNotificaciones>> GetAllAsync(){
            return await _context.TipoNotificaciones
            .Include( p => p.BlockChains)
            .Include(m => m.ModuloNoficaciones)
            .ToListAsync();
        }

        public async Task<List<BlockChain>> GetBlockChainsAsync(int TiponotiId){
            return await _context.BlockChains.Where(p => p.IdNotificacionFk == TiponotiId).ToListAsync();
        }

        public async Task<List<ModuloNoficaciones>> GetModuloNotificaciones(int TiponotiId2){
            return await _context.ModuloNoficaciones.Where(p => p.IdNotificacionFk == TiponotiId2).ToListAsync();
        }

        public async Task<TipoNotificaciones> GetIdAsync(int id){
            return await _context.TipoNotificaciones
            .Include(p => p.BlockChains)
            .Include(m => m.ModuloNoficaciones)
            .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}