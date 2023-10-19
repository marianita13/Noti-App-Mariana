using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IHiloRespuestaNot : IGenericRepository<HiloRespuestaNot>
    {
        Task<List<BlockChain>> GetBlockChainsAsync(int HiloResId);
        Task<List<ModuloNoficaciones>> GetModuloNotificaciones(int HiloResId2);
    }
}