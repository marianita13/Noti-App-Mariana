using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace APINOTI.Dtos
{
    public class TipoNotiDto
    {
        public int Id { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string NombreTipo { get; set; }
        public ICollection<BlockChain> BlockChains {get; set;}
        public ICollection<ModuloNoficaciones> ModuloNoficaciones {get; set;}
    }
}