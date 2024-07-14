using Microsoft.AspNetCore.Mvc;
using OrderManagement.Application.Interfaces.IServices;
using OrderManagement.Domain.Entities;

namespace OrderManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;
        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }
        [Route("GetAllItem")]
        [HttpGet]
        public async Task<ActionResult<List<Item>>> GetAllItem()
        {
            return Ok(await _itemService.GetAllItem());
        }
    }
}
