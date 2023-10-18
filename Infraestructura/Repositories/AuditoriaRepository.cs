using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infraestructura.Data;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Repositories
{
    public class AuditoriaRepository : GenericRepository<Auditoria>, IAuditoria
    {
        private readonly NotiAppContext _context;
        public AuditoriaRepository(NotiAppContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Auditoria>> GetAllAsync(){
            return await _context.Auditorias
            .Include(p => p.BlockChains)
            .ToListAsync();
        }

        public async Task<List<BlockChain>> GetBlockChainsAsync(int AuditoriaId){
            return await _context.BlockChains.Where(p => p.IdAuditoriaFk == AuditoriaId).ToListAsync();
        }

        public async Task<Auditoria> GetIdAsync(int id){
            return await _context.Auditorias
            .Include(p => p.BlockChains)
            .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}