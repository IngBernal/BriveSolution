using Brive.Core.Entities;
using System.Threading.Tasks;

namespace Brive.Core.Interfaces.IRepositories
{
    public interface ISucursalARepository : IGenericRepository<SucursalA>
    {
        Task<SucursalA> GetProductByCode(string code);
        Task<decimal> GetUnirPrice(string code);
        Task<SucursalA> GetQuantity(string code);
    }
}
