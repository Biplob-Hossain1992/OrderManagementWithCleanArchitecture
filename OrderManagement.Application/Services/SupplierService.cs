using OrderManagement.Application.Interfaces.IRepositories;
using OrderManagement.Application.Interfaces.IServices;
using OrderManagement.Domain.Entities;

namespace OrderManagement.Application.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;
        public SupplierService(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }
        public async Task<List<Supplier>> GetAllSupplier()
        {
            var response = await _supplierRepository.GetAllSupplier();
            //set if any business logic
            return response;
        }
    }
}
