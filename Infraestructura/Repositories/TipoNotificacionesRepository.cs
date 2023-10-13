using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infraestructura.Data;

namespace Infraestructura.Repositories
{
    public class TipoNotificacionesRepository : GenericRepository<TipoNotificaciones>, ITipoNotificaciones
    {
        private readonly NotiAppContext _context;
        public TipoNotificacionesRepository(NotiAppContext context) : base(context)
        {
            _context = context;
        }
    }
}