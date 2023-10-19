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
    public class HiloRespuestaRepository : GenericRepository<HiloRespuestaNot>, IHiloRespuestaNot
    {
        private readonly NotiAppContext _context;
        public HiloRespuestaRepository(NotiAppContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<HiloRespuestaNot>> GetAllAsync(){
            return await _context.HiloRespuestaNots
            .Include( p => p.BlockChains)
            .Include(m => m.ModuloNoficaciones)
            .ToListAsync();
        }

        public async Task<List<BlockChain>> GetBlockChainsAsync(int HiloResId){
            return await _context.BlockChains.Where(p => p.IdHiloRespuestaFk == HiloResId).ToListAsync();
        }

        public async Task<List<ModuloNoficaciones>> GetModuloNotificaciones(int HiloResId2){
            return await _context.ModuloNoficaciones.Where(p => p.IdHiloRespuestaFk == HiloResId2).ToListAsync();
        }

        public async Task<HiloRespuestaNot> GetIdAsync(int id){
            return await _context.HiloRespuestaNots
            .Include(p => p.BlockChains)
            .Include(m => m.ModuloNoficaciones)
            .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}