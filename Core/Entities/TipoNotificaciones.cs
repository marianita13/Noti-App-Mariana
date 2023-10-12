using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class TipoNotificaciones : BaseEntity
    {
        public string NombreTipo { get; set; }
        public ICollection<BlockChain> BlockChains {get; set;}
        public ICollection<ModuloNoficaciones> ModuloNoficaciones {get; set;}
    }
}