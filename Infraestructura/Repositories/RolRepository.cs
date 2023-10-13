using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infraestructura.Data;

namespace Infraestructura.Repositories
{
    public class RolRepository : GenericRepository<Rol>, IRol
    {
        private readonly NotiAppContext _context;
        public RolRepository(NotiAppContext context) : base(context)
        {
            _context = context;
        }
    }
}