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

        private IAuditoria _Auditorias;
        private IBlockChain _BlockChains;
        private IEstadoNotificacion _EstadosNots;
        private IFormato _Formatos;
        private IGenericosvsSubModulos _GenericosVSSubModulos;
        private IHiloRespuestaNot _HilosRespuestas;
        private IMaestrosvsSubModulos _MaestrosVSSubModulos;
        private IModuloNotificaciones _ModuloNotificaciones;
        private IModulosMaestros _modulosMaestros;
        private IPermisosGenericos _PermisosGenericos;
        private IRadicados _Radicados;
        private IRol _Roles;
        private IRolvsMaestro _RolesVSMaestros;
        private ISubModulo _SubModulos;
        private ITipoNotificaciones _TiposNost;
        private ITipoRequerimiento _TipoRequerimientos;

        public IAuditoria Auditorias {
            get{
                if (_Auditorias == null){
                    _Auditorias = new AuditoriaRepository(_context);
                }
                return _Auditorias;
            }
        }

        public IBlockChain BlockChains {
            get{
                if (_BlockChains == null){
                    _BlockChains = new BlockChainRepository(_context);
                }
                return _BlockChains;
            }
        }

        public IEstadoNotificacion EstadoNotificaciones {
            get{
                if (_EstadosNots == null){
                    _EstadosNots = new EstadoNotRepository(_context);
                }
                return _EstadosNots;
            }
        }
        public IFormato Formatos {
            get{
                if(_Formatos == null){
                    _Formatos = new FormatoRepository(_context);
                }
                return _Formatos;
            }
        }
        public IGenericosvsSubModulos GenericosvsSubModulos{
            get{
                if(_GenericosVSSubModulos == null){
                    _GenericosVSSubModulos = new GenericosVSSubModRepository(_context);
                }
                return _GenericosVSSubModulos;
            }
        }
        public IHiloRespuestaNot HiloRespuestas {
            get{
                if (_HilosRespuestas == null){
                    _HilosRespuestas = new HiloRespuestaRepository(_context);
                }
                return _HilosRespuestas;
            }
        }
        public IMaestrosvsSubModulos MaestrosvsSubModulos{
            get{
                if (_MaestrosVSSubModulos == null){
                    _MaestrosVSSubModulos = new MaestroVSSubModRepository(_context);
                }
                return _MaestrosVSSubModulos;
            }
        }
        public IModulosMaestros ModuloMaestros {
            get{
                if (_modulosMaestros == null){
                    _modulosMaestros = new ModuloMaestrosRepository(_context);
                }
                return _modulosMaestros;
            }
        }

        public IModuloNotificaciones ModuloNotificaciones {
            get{
                if (_ModuloNotificaciones == null){
                    _ModuloNotificaciones = new ModuloNotiRepository(_context);
                }
                return _ModuloNotificaciones;
            }
        }

        public IPermisosGenericos PermisosGenericos {
            get{
                if (_PermisosGenericos == null){
                    _PermisosGenericos = new PermisosGenericosRepository(_context);
                }
                return _PermisosGenericos;
            }
        }

        public IRadicados Radicados {
            get{
                if (_Radicados == null){
                    _Radicados = new RadicadosRepository(_context);
                }
                return _Radicados;
            }
        }
        public IRol Roles{
            get{
                if(_Roles == null){
                    _Roles = new RolRepository(_context);
                }
                return _Roles;
            }
        }
        public IRolvsMaestro RolvsMaestro{
            get{
                if(_RolesVSMaestros == null){
                    _RolesVSMaestros = new RolVSMaestrosRepository(_context);
                }
                return _RolesVSMaestros;
            }
        }
        public ISubModulo SubModulos {
            get{
                if(_SubModulos == null){
                    _SubModulos = new SubModulosRepository(_context);
                }
                return _SubModulos;
            }
        }

        public ITipoRequerimiento TipoRequerimientos {
            get{
                if(_TipoRequerimientos == null){
                    _TipoRequerimientos = new TipoRequerimientoRepository(_context);
                }
                return _TipoRequerimientos;
            }
        }

        public ITipoNotificaciones TipoNotificaciones {
            get{
                if(_TiposNost == null){
                    _TiposNost = new TipoNotificacionesRepository(_context);
                }
                return _TiposNost;
            }
        }

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