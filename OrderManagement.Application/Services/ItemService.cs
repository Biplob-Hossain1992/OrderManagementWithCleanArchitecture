using OrderManagement.Application.Interfaces.IRepositories;
using OrderManagement.Application.Interfaces.IServices;
using OrderManagement.Domain.Entities;

namespace OrderManagement.Application.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;
        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }
        public async Task<List<Item>> GetAllItem()
        {
            var response = await _itemRepository.GetAllItem();
            //set if any business logic
            return response;
        }
    }
}
