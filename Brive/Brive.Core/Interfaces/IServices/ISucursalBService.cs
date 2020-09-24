using Brive.Core.Entities;
using Brive.Core.QueryFilter;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Brive.Core.Interfaces.IServices
{
    public interface ISucursalBService
    {

        Task<List<SucursalB>> GetAllSucursalB(SucursalQueryFilter filter);
        Task<SucursalB> GetSucursalBById(int id);
        Task AddSucursalB(SucursalB model);
        Task UpdateSucursalB(SucursalB model);
        Task RemoveSucursalB(SucursalB model);
    }
}
