using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infraestructura.Data;

namespace Infraestructura.Repositories
{
    public class MaestroVSSubModRepository : GenericRepository<MaestrosvsSubModulos>, IMaestrosvsSubModulos
    {
        private readonly NotiAppContext _context;
        public MaestroVSSubModRepository(NotiAppContext context) : base(context)
        {
            _context = context;
        }
    }
}