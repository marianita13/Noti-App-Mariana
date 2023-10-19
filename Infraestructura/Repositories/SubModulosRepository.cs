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
    public class SubModulosRepository : GenericRepository<SubModulos>, ISubModulo
    {
        private readonly NotiAppContext _context;
        public SubModulosRepository(NotiAppContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<SubModulos>> GetAllAsync(){
            return await _context.SubModulos
            .Include(m => m.MaestrosvsSubModulos)
            .ToListAsync();
        }

        public async Task<List<MaestrosvsSubModulos>> GetMaestrosVsSubModulos(int Id){
            return await _context.MaestrosvsSubModulos.Where(p => p.IdSubModulo == Id).ToListAsync();
        }

        public async Task<SubModulos> GetIdAsync(int id){
            return await _context.SubModulos
            .Include(m => m.MaestrosvsSubModulos)
            .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}