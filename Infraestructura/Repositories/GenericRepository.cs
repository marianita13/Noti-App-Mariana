using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Infraestructura.Data;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Repositories
{
    public class GenericRepository<T> where T : BaseEntity
    {
        private NotiAppContext _context;
        public GenericRepository(NotiAppContext context)
        {
            _context = context;
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync(){
            return await _context.Set<T>().ToListAsync();
        }
        public virtual async Task<T> GetIDAsync(){
            return await _context.Set<T>().FindAsync();
        }
        public virtual void Add(T entity){
            _context.Set<T>().Add(entity);
        }
        
    }
}