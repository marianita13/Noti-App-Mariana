using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Auditoria : BaseEntity
    {
        [Required]
        public string NombreUsuario { get; set; }
        public int DesAccion { get; set; }
        public ICollection<BlockChain> BlockChains {get; set;}
    }
}