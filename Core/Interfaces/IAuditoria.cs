using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IAuditoria : IGenericRepository<Auditoria>
    {
        Task<List<BlockChain>> GetBlockChainsAsync(int AuditoriaId);
    }

}