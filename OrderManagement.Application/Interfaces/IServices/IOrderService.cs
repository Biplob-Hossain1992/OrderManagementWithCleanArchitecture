using OrderManagement.Application.ViewModel;

namespace OrderManagement.Application.Interfaces.IServices
{
    public interface IOrderService
    {
        Task<VmResponseMessage> CreateOrder(VmOrder vm);
        Task<List<VmOrderItem>> GetById(int id);
        Task<List<VmOrder>> GetAllOrder();
        Task<VmResponseMessage> UpdateOrder(VmOrder vm);
        Task<VmResponseMessage> RemoveOrder(int id);
    }
}
