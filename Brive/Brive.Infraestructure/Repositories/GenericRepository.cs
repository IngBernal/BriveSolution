using Brive.Core.Entities;
using Brive.Core.Interfaces.IRepositories;
using Brive.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Brive.Infraestructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly BriveContext _context;
        protected readonly DbSet<T> _entities;

        public GenericRepository(BriveContext context)
        {
            _context = context;
            _entities = _context.Set<T>();
        }
        
        public async Task<List<T>> GetAllGeneric()
        {
            return await _entities.ToListAsync();
        }

        public async Task<T> GetByIdGeneric(int id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task AddGeneric(T model)
        {
            await _entities.AddAsync(model);
        }

        public void UpdateGeneric(T model)
        {
            _entities.Update(model);
        }

        public async Task RemoveGeneric(int id)
        {
            T entity = await GetByIdGeneric(id);
            _entities.Remove(entity);
        }
    }
}
