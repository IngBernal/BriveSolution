using Brive.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Brive.Core.Interfaces.IRepositories
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAllGeneric();
        Task<T> GetByIdGeneric(int id);
        Task AddGeneric(T model);
        void UpdateGeneric(T model);
        Task RemoveGeneric(int id);
    }
}
