using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infraestructura.Data;
using Infraestructura.Repositories;

namespace Infraestructura.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly NotiAppContext _context;
        public UnitOfWork(NotiAppContext context)
        {
            _context = context;
        }

        public IAuditoria _Auditorias;
        public IBlockChain _BlockChains;
        public IEstadoNotificacion _EstadosNots;
        public IFormato _Formatos;
        public IGenericosvsSubModulos _GenericosVSSubModulos;
        public IHiloRespuestaNot _HilosRespuestas;
        public IMaestrosvsSubModulos _MaestrosVSSubModulos;
        public IModuloNotificaciones _ModuloNotificaciones;
        public IPermisosGenericos _PermisosGenericos;
        public IRadicados _Radicados;
        public IRol _Roles;
        public IRolvsMaestro _RolesVSMaestros;
        public ISubModulo _SubModulos;
        public ITipoNotificaciones _TiposNost;
        public ITipoRequerimiento _TipoRequerimientos;

        // public IAuditoria Auditoria{
        //     get{
        //         if (_Auditorias == null){
        //             _Auditorias = new AuditoriaRepository(_context);
        //         }
        //         return _Auditorias;
        //     }
        // }


        public Task<int> SaveAsync()
        {
            return _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}