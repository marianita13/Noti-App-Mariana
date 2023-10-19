using Core.Entities;
using Core.Interfaces;
using Infraestructura.Data;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Repositories
{
    public class FormatoRepository : GenericRepository<Formatos>, IFormato
    {
        private readonly NotiAppContext _context;
        public FormatoRepository(NotiAppContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Formatos>> GetAllAsync(){
            return await _context.Formatos
            .Include(m => m.ModuloNoficaciones)
            .ToListAsync();
        }

        public async Task<List<ModuloNoficaciones>> GetModuloNotificaciones(int formatoId){
            return await _context.ModuloNoficaciones.Where(p => p.IdFormatoFk == formatoId).ToListAsync();
        }

        public async Task<Formatos> GetIdAsync(int id){
            return await _context.Formatos
            .Include(m => m.ModuloNoficaciones)
            .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}