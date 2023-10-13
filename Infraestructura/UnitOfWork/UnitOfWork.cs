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
        public IModulosMaestros _modulosMaestros;
        public IPermisosGenericos _PermisosGenericos;
        public IRadicados _Radicados;
        public IRol _Roles;
        public IRolvsMaestro _RolesVSMaestros;
        public ISubModulo _SubModulos;
        public ITipoNotificaciones _TiposNost;
        public ITipoRequerimiento _TipoRequerimientos;

        public IAuditoria Auditoria{
            get{
                if (_Auditorias == null){
                    _Auditorias = new AuditoriaRepository(_context);
                }
                return _Auditorias;
            }
        }

        public IBlockChain BlockChain{
            get{
                if (_BlockChains == null){
                    _BlockChains = new BlockChainRepository(_context);
                }
                return _BlockChains;
            }
        }
        public IEstadoNotificacion EstadoNotificacion{
            get{
                if (_EstadosNots == null){
                    _EstadosNots = new EstadoNotRepository(_context);
                }
                return _EstadosNots;
            }
        }
        public IFormato Formato{
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
        public IHiloRespuestaNot HiloRespuestaNot{
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
        public IModuloNotificaciones ModuloNotificaciones{
            get{
                if (_ModuloNotificaciones == null){
                    _ModuloNotificaciones = new ModuloNotiRepository(_context);
                }
                return _ModuloNotificaciones;
            }
        }
        public IModulosMaestros ModulosMaestros{
            get{
                if (_modulosMaestros == null){
                    _modulosMaestros = new ModuloMaestrosRepository(_context);
                }
                return _modulosMaestros;
            }
        }

        public IPermisosGenericos PermisosGenericos{
            get{
                if (_PermisosGenericos == null){
                    _PermisosGenericos = new PermisosGenericosRepository(_context);
                }
                return _PermisosGenericos;
            }
        }
        public IRadicados Radicados{
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

        public ISubModulo SubModulo{
            get{
                if(_SubModulos == null){
                    _SubModulos = new SubModulosRepository(_context);
                }
                return _SubModulos;
            }
        }
        public ITipoNotificaciones TipoNotificaciones{
            get{
                if(_TiposNost == null){
                    _TiposNost = new TipoNotificacionesRepository(_context);
                }
                return _TiposNost;
            }
        }
        public ITipoRequerimiento TipoRequerimiento{
            get{
                if(_TipoRequerimientos == null){
                    _TipoRequerimientos = new TipoRequerimientoRepository(_context);
                }
                return _TipoRequerimientos;
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