using Core.Entities;
using Core.Interfaces;
using Infraestructura.Data;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Repositories
{
    public class RadicadosRepository : GenericRepository<Radicados>, IRadicados
    {
        private readonly NotiAppContext _context;
        public RadicadosRepository(NotiAppContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Radicados>> GetAllAsync(){
            return await _context.Radicados
            .Include(m => m.ModuloNoficaciones)
            .ToListAsync();
        }

        public async Task<List<ModuloNoficaciones>> GetModuloNotificaciones(int Id){
            return await _context.ModuloNoficaciones.Where(p => p.IdRadicadoFk == Id).ToListAsync();
        }

        public async Task<Radicados> GetIdAsync(int id){
            return await _context.Radicados
            .Include(m => m.ModuloNoficaciones)
            .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}