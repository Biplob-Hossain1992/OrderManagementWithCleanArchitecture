using OrderManagement.Application.ViewModel;
using OrderManagement.Domain.Entities;

namespace OrderManagement.Application.Interfaces.IRepositories
{
    public interface IOrderRepository
    {
        Task<VmResponseMessage> CreateOrder(VmOrder vm);
        Task<List<VmOrderItem>> GetById(int id);
        Task<List<VmOrder>> GetAllOrder(int CurPage, int TakeRows);
        Task<VmResponseMessage> UpdateOrder(VmOrder vm);
        Task<VmResponseMessage> RemoveOrder(int id);
    }
}
