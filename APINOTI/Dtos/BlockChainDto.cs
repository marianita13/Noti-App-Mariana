using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APINOTI.Dtos
{
    public class BlockChainDto
    {
        public int Id { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string HashGenerado { get; set; }
        public int IdAuditoriaFk { get; set; } 
        public int IdHiloRespuestaFk { get; set; }
        public int IdNotificacionFk { get; set; }
    }
}