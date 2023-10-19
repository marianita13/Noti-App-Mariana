using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace APINOTI.Dtos
{
    public class ModuloMaestrosDto
    {
        public int Id { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string NombreModulo { get; set; }
        public List<RolvsMaestro> RolvsMaestros {get; set;}
        public List<MaestrosvsSubModulos> MaestrosvsSubModulos {get; set;}
    }
}