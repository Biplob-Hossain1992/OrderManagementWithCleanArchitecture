using OrderManagement.Application.ViewModel;
using OrderManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Application.Interfaces.IServices
{
    public interface IOrderService
    {
        Task<VmResponseMessage> CreateOrder(VmOrder vm);
        Task<Order> GetById(int id);
        Task<List<VmOrder>> GetAllOrder();
        Task<VmResponseMessage> UpdateOrder(VmOrder vm);
        Task<VmResponseMessage> RemoveOrder(int id);
    }
}
