using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class BlockChain : BaseEntity
    {
        [Required]
        public string HashGenerado { get; set; }

        public Auditoria Auditorias { get; set; }
        public int IdAuditoriaFk { get; set; } 

        public HiloRespuestaNot HiloRespuestaNots {get; set;}
        public int IdHiloRespuestaFk { get; set; }

        public TipoNotificaciones TipoNots {get; set;}
        public int IdNotificacionFk { get; set; }
    }
}