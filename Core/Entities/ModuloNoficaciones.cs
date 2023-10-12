using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class ModuloNoficaciones : BaseEntity
    {
        public string AsuntoNotificacion { get; set; }
        public string TextoNotificacion { get; set; }

        //FORANEAS
        public TipoNotificaciones TipoNotificacion { get; set; }
        public int IdNotificacionFk { get; set; }

        public Radicados Radicado { get; set; }
        public int IdRadicadoFk { get; set; }

        public EstadoNotificacion EstadoNot { get; set; }
        public int IdEstadoNotificacionFk { get; set; }

        public HiloRespuestaNot HiloRespuestaNots { get; set; }
        public int IdHiloRespuestaFk { get; set; }

        public Formatos Formatos { get; set; }
        public int IdFormatoFk { get; set; }

        public TipoRequerimiento Requerimientos { get; set; }
        public int IdRequerimiento { get; set; }
    }
}