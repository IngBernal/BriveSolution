using Brive.Core.Entities;
using Brive.Core.Interfaces;
using Brive.Core.Interfaces.IServices;
using Brive.Core.QueryFilter;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Brive.Core.Services
{
    public class SucursalBService : ISucursalBService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SucursalBService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<SucursalB>> GetAllSucursalB(SucursalQueryFilter filter)
        {
            return await _unitOfWork.SucursalBRepository.GetAllGeneric();
        }

        public async Task<SucursalB> GetSucursalBById(int id)
        {

            return await _unitOfWork.SucursalBRepository.GetByIdGeneric(id);
        }

        public async Task AddSucursalB(SucursalB model)
        {
            var price = await _unitOfWork.SucursalBRepository.GetUnirPrice(model.Code);
            model.UnitPrice = price;
            await _unitOfWork.SucursalBRepository.AddGeneric(model);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateSucursalB(SucursalB model)
        {
            var product = await _unitOfWork.SucursalBRepository.GetQuantity(model.Code);
            product.Quantity += model.Quantity;
            _unitOfWork.SucursalBRepository.UpdateGeneric(product);
            await _unitOfWork.CommitAsync();
        }

        public async Task RemoveSucursalB(SucursalB model)
        {
            var product = await _unitOfWork.SucursalBRepository.GetProductByCode(model.Code);

            if (model.Quantity > product.Quantity)
                throw new Exception("No contamos con la cantidad de productos a comprar.");

            product.Quantity -= model.Quantity;
            _unitOfWork.SucursalBRepository.UpdateGeneric(product);
            await _unitOfWork.CommitAsync();
        }
    }
}
