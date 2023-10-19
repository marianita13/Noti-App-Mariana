using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IModulosMaestros : IGenericRepository<ModulosMaestros>
    {
        Task<List<RolvsMaestro>> GetRolvsMaestros(int TiponotiId);
        Task<List<MaestrosvsSubModulos>> GetMaestrosvsSubModulos(int TiponotiId2);
    }
}