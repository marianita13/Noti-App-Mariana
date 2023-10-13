using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APINOTI.Dtos
{
    public class ModuloNotificacionesDto
    {
        public int Id { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string AsuntoNotificacion { get; set; }
        public string TextoNotificacion { get; set; }
    }
}