using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface ITipoNotificaciones : IGenericRepository<TipoNotificaciones>
    {
        Task<List<BlockChain>> GetBlockChainsAsync(int TiponotiId);
        Task<List<ModuloNoficaciones>> GetModuloNotificaciones(int TiponotiId2);
    }
}