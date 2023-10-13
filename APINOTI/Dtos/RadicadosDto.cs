using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace APINOTI.Dtos
{
    public class RadicadosDto
    {
        public int Id { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public ICollection<ModuloNoficaciones> ModuloNoficaciones {get; set;}

    }
}