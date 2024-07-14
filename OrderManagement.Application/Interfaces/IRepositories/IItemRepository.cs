using OrderManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Application.Interfaces.IRepositories
{
    public interface IItemRepository
    {
        Task<List<Item>> GetAllItem();
    }
}
