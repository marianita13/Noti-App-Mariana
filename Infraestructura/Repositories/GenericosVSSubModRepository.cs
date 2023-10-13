using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infraestructura.Data;

namespace Infraestructura.Repositories
{
    public class GenericosVSSubModRepository : GenericRepository<GenericosvsSubModulos>, IGenericosvsSubModulos
    {
        private readonly NotiAppContext _context;
        public GenericosVSSubModRepository(NotiAppContext context) : base(context)
        {
            _context = context;
        }
    }
}