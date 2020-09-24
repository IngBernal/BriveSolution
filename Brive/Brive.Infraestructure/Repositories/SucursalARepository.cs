using Brive.Core.Entities;
using Brive.Core.Interfaces.IRepositories;
using Brive.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Brive.Infraestructure.Repositories
{
    public class SucursalARepository : GenericRepository<SucursalA>, ISucursalARepository
    {
        public SucursalARepository(BriveContext context) : base(context)
        {
        }

        public async Task<SucursalA> GetProductByCode(string code)
        {
            return await _entities.Where(x => x.Code == code).FirstOrDefaultAsync();
        }

        public async Task<SucursalA> GetQuantity(string code)
        {
            return await _entities.Where(x => x.Code == code).FirstOrDefaultAsync();            
        }

        public async Task<decimal> GetUnirPrice(string code)
        {
            var product = await _context.Prodcuts.Where(x => x.Code == code).FirstOrDefaultAsync();
            return product.UnitPrice;
        }
    }
}
