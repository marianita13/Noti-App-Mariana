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
    public class RolRepository : GenericRepository<Rol>, IRol
    {
        private readonly NotiAppContext _context;
        public RolRepository(NotiAppContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Rol>> GetAllAsync(){
            return await _context.Roles
            .Include(m => m.RolvsMaestros)
            .ToListAsync();
        }

        public async Task<List<RolvsMaestro>> GetRolvsMaestrosAsync(int Id){
            return await _context.RolvsMaestros.Where(p => p.IdRolFk == Id).ToListAsync();
        }

        public async Task<Rol> GetIdAsync(int id){
            return await _context.Roles
            .Include(m => m.RolvsMaestros)
            .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}