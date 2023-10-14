using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IUnitOfWork
    {
        IAuditoria Auditorias {get;}
        IBlockChain BlockChains {get;}
        IEstadoNotificacion EstadoNotificaciones {get;}
        IFormato Formatos {get;}
        IHiloRespuestaNot HiloRespuestas {get;}
        IModulosMaestros ModuloMaestros {get;}
        IModuloNotificaciones ModuloNotificaciones {get;}
        IPermisosGenericos PermisosGenericos {get;}
        IRadicados Radicados {get;}
        IRol Roles {get;}
        ISubModulo SubModulos {get;}
        ITipoRequerimiento TipoRequerimientos {get;}
        ITipoNotificaciones TipoNotificaciones {get;}
        Task<int> SaveAsync();
    }
}