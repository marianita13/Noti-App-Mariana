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
    public class ModuloMaestrosRepository : GenericRepository<ModulosMaestros>, IModulosMaestros
    {
        private readonly NotiAppContext _context;
        public ModuloMaestrosRepository(NotiAppContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<ModulosMaestros>> GetAllAsync(){
            return await _context.ModulosMaestros
            .Include( p => p.RolvsMaestros)
            .Include(m => m.MaestrosvsSubModulos)
            .ToListAsync();
        }

        public async Task<List<RolvsMaestro>> GetRolvsMaestros(int Id){
            return await _context.RolvsMaestros.Where(p => p.IdRolFk == Id).ToListAsync();
        }

        public async Task<List<MaestrosvsSubModulos>> GetMaestrosvsSubModulos(int Id2){
            return await _context.MaestrosvsSubModulos.Where(p => p.IdMaestro == Id2).ToListAsync();
        }

        public async Task<ModulosMaestros> GetIdAsync(int id){
            return await _context.ModulosMaestros
            .Include(p => p.RolvsMaestros)
            .Include(m => m.MaestrosvsSubModulos)
            .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}