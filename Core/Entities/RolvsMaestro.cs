using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class RolvsMaestro : BaseEntity
    {
        public Rol Roles { get; set; }
        public int IdRolFk { get; set; }

        public ModulosMaestros Maestros { get; set; }
        public int IdMaestros { get; set; }
    }
}