using Core.Entities;
using Core.Interfaces;
using Infraestructura.Data;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Repositories
{
    public class EstadoNotRepository : GenericRepository<EstadoNotificacion>, IEstadoNotificacion
    {
        private readonly NotiAppContext _context;
        public EstadoNotRepository(NotiAppContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<EstadoNotificacion>> GetAllAsync(){
            return await _context.EstadoNotificaciones
            .Include(m => m.ModuloNoficaciones)
            .ToListAsync();
        }

        public async Task<List<ModuloNoficaciones>> GetModuloNotificaciones(int EstadoNotiId){
            return await _context.ModuloNoficaciones.Where(p => p.IdEstadoNotificacionFk == EstadoNotiId).ToListAsync();
        }

        public async Task<EstadoNotificacion> GetIdAsync(int id){
            return await _context.EstadoNotificaciones
            .Include(m => m.ModuloNoficaciones)
            .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}