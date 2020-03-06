using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NetCore.Framework;

namespace NetCore.Infraestructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly NetCoreContext _context;

        public UnitOfWork(NetCoreContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task CompleteAsync(CancellationToken token)
        {
            await _context.SaveChangesAsync(token);
        }
    }
}
