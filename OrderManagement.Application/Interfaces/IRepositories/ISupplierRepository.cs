using OrderManagement.Domain.Entities;

namespace OrderManagement.Application.Interfaces.IRepositories
{
    public interface ISupplierRepository
    {
        Task<List<Supplier>> GetAllSupplier();
    }
}
