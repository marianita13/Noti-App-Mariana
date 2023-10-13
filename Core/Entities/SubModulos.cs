using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class SubModulos : BaseEntity
    {
        public string NombreSubmodulo { get; set; }
        public ICollection<MaestrosvsSubModulos> MaestrosvsSubModulos {get; set;}
    }
}