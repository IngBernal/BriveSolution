using Brive.Core.Entities;
using System.Threading.Tasks;

namespace Brive.Core.Interfaces.IRepositories
{
    public interface ISucursalBRepository: IGenericRepository<SucursalB>
    {
        Task<SucursalB> GetProductByCode(string code);
        Task<SucursalB> GetQuantity(string code);
        Task<decimal> GetUnirPrice(string code);
    }
}
