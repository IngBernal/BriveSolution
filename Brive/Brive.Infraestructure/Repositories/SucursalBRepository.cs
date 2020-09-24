using Brive.Core.Entities;
using Brive.Core.Interfaces.IRepositories;
using Brive.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Brive.Infraestructure.Repositories
{
    public class SucursalBRepository : GenericRepository<SucursalB>, ISucursalBRepository
    {
        public SucursalBRepository(BriveContext context) : base(context)
        {
        }

        public async Task<SucursalB> GetProductByCode(string code)
        {
            return await _entities.Where(x => x.Code == code).FirstOrDefaultAsync();
        }

        public async Task<SucursalB> GetQuantity(string code)
        {
            var product = await _entities.Where(x => x.Code == code).FirstOrDefaultAsync();
            return product;
        }

        public async Task<decimal> GetUnirPrice(string code)
        {
            var product = await _context.Prodcuts.Where(x => x.Code == code).FirstOrDefaultAsync();
            return product.UnitPrice;
        }
    }
}
