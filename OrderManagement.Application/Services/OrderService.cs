using OrderManagement.Application.Interfaces.IRepositories;
using OrderManagement.Application.Interfaces.IServices;
using OrderManagement.Application.ViewModel;
using OrderManagement.Domain.Entities;

namespace OrderManagement.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<VmResponseMessage> CreateOrder(VmOrder vm)
        {
            var response =  await _orderRepository.CreateOrder(vm);
            return response;
        }
        public async Task<List<VmOrderItem>> GetById(int id)
        {
            var response = await _orderRepository.GetById(id);
            return response;
        }
        public async Task<List<VmOrder>> GetAllOrder()
        {
            var response = await _orderRepository.GetAllOrder();
            //set if any business logic
            return response;
        }
        public async Task<VmResponseMessage> UpdateOrder(VmOrder vm)
        {
            var response = await _orderRepository.UpdateOrder(vm);
            return response;
        }
        public async Task<VmResponseMessage> RemoveOrder(int id)
        {
            var response = await _orderRepository.RemoveOrder(id);
            return response;
        }
    }
}
