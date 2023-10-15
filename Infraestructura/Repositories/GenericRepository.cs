using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
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
        public virtual async Task<T> GetIdAsync(int id){
            return await _context.Set<T>().FindAsync(id);
        }

        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> expression){
            return _context.Set<T>().Where(expression);
        }
        public virtual void Add(T entity){
            _context.Set<T>().Add(entity);
        }
        
        public virtual void AddRange(IEnumerable<T> entities){
            _context.Set<T>().AddRange(entities);
        }

        public virtual void Remove(T entity){
            _context.Set<T>().Remove(entity);
        }

        public virtual void RemoveRange(IEnumerable<T> entities){
            _context.Set<T>().RemoveRange(entities);
        }

        public void Update(T entity){
            _context.Set<T>().Update(entity);
        }
    }
}