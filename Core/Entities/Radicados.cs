using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Radicados : BaseEntity
    {
        public ICollection<ModuloNoficaciones> ModuloNoficaciones {get; set;}
    }
}