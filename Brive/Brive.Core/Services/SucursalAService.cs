using Brive.Core.Entities;
using Brive.Core.Interfaces;
using Brive.Core.Interfaces.IServices;
using Brive.Core.QueryFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brive.Core.Services
{
    public class SucursalAService : ISucursalAService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SucursalAService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<SucursalA>> GetAllSucursalA(SucursalQueryFilter filter)
        {
            var products = await _unitOfWork.SucursalARepository.GetAllGeneric();
         
            if(filter.Code != null)            
                products = products.Where(x => x.Code == filter.Code).ToList();
            
            return products;
        }

        public async Task<SucursalA> GetSucursalAByCode(string code)
        {
            return await _unitOfWork.SucursalARepository.GetProductByCode(code);
        }

        public async Task AddSucursalA(SucursalA model)
        {
            var price = await _unitOfWork.SucursalARepository.GetUnirPrice(model.Code);
            model.UnitPrice = price;
            await _unitOfWork.SucursalARepository.AddGeneric(model);            
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateSucursalA(SucursalA model)
        {
            var product = await _unitOfWork.SucursalARepository.GetQuantity(model.Code);
            product.Quantity += model.Quantity;
            _unitOfWork.SucursalARepository.UpdateGeneric(product);
            await _unitOfWork.CommitAsync();
        }

        public async Task RemoveSucursalA(SucursalA model)
        {
            var product = await _unitOfWork.SucursalARepository.GetProductByCode(model.Code);
            
            if(model.Quantity > product.Quantity)
                throw new Exception("No contamos con la cantidad de productos a comprar.");

            product.Quantity -= model.Quantity;
            _unitOfWork.SucursalARepository.UpdateGeneric(product);
            await _unitOfWork.CommitAsync();
        }
    }
}
