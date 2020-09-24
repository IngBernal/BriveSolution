using Brive.Core.Interfaces;
using Brive.Core.Interfaces.IRepositories;
using Brive.Infraestructure.Data;
using System;
using System.Threading.Tasks;

namespace Brive.Infraestructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BriveContext _context;
        private readonly ISucursalARepository _sucursalARepository;
        private readonly ISucursalBRepository _sucursalBRepository;

        public UnitOfWork(BriveContext context)
        {
            _context = context;
        }


        public ISucursalARepository SucursalARepository => _sucursalARepository ?? new SucursalARepository(_context);
        public ISucursalBRepository SucursalBRepository => _sucursalBRepository ?? new SucursalBRepository(_context);

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            if (_context != null)
            {
                _context.DisposeAsync();
            }
        }
    }
}
