using Brive.Core.Entities;
using Brive.Core.QueryFilter;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Brive.Core.Interfaces.IServices
{
    public interface ISucursalAService
    {
        Task<List<SucursalA>> GetAllSucursalA(SucursalQueryFilter filter);
        Task<SucursalA> GetSucursalAByCode(string code);
        Task AddSucursalA(SucursalA model);
        Task UpdateSucursalA(SucursalA model);
        Task RemoveSucursalA(SucursalA model);
    }
}
