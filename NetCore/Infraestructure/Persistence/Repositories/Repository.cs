using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NetCore.Framework;

namespace NetCore.Infraestructure.Persistence.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected readonly NetCoreContext _context;

        public Repository(NetCoreContext context)
        {
            _context = context;
        }

        public virtual async Task<IEnumerable<T>> ListAsync()
        {
            return await _context.Set<T>()
                                 .AsNoTracking()
                                 .ToListAsync();
        }

        public virtual async Task<T> FindByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public virtual async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public virtual void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public virtual void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

    }
}
