using System;
using RedTeam.Repositories.Interfaces;
using System.Threading.Tasks;

namespace RedTeam.Repositories
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly IContext _context;

        public UnitOfWork(IContext context)
        {
            _context = context;
        }
        public void Rollback()
        {
            throw new NotImplementedException();
        }

        public async Task<int> Commit()
        {
            return await _context.SaveAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this); 
        }

        protected virtual void Dispose(bool disposing)
        { }
    }
}

