using Brive.Core.Interfaces.IRepositories;
using System;
using System.Threading.Tasks;


namespace Brive.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ISucursalARepository SucursalARepository { get; }
        ISucursalBRepository SucursalBRepository { get; }
        Task CommitAsync();
    }
}
