using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class GenericosvsSubModulos : BaseEntity
    {
        public PermisosGenericos permisosGenericos { get; set; }
        public int IdPermisosFk { get; set; }

        public Rol Roles { get; set; }
        public int IdRolFk { get; set; }

        public MaestrosvsSubModulos MaestrosvsSub { get; set; }
        public int IdSubModulos { get; set; }


    }
}