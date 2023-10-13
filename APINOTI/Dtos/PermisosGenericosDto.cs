using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace APINOTI.Dtos
{
    public class PermisosGenericosDto
    {
        public int Id { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string NombrePermiso { get; set; }
        public ICollection<GenericosvsSubModulos> GenericosvsSubModulos {get; set;}
    }
}