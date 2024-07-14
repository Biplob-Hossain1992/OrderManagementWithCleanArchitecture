using OrderManagement.Domain.Entities;

namespace OrderManagement.Application.Interfaces.IServices
{
    public interface ISupplierService
    {
        Task<List<Supplier>> GetAllSupplier();
    }
}
