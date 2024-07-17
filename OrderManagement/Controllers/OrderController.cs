using Microsoft.AspNetCore.Mvc;
using OrderManagement.Application.Interfaces.IServices;
using OrderManagement.Application.ViewModel;
using OrderManagement.Domain.Entities;

namespace OrderManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [Route("CreateOrder")]
        [HttpPost]
        public async Task<ActionResult<VmResponseMessage>> CreateOrder(VmOrder vm)
        {
            return Ok(await _orderService.CreateOrder(vm));
        }
        [Route("GetById")]
        [HttpGet]
        public async Task<ActionResult<Order>> GetById(int id)
        {
            return Ok(await _orderService.GetById(id));
        }
        [Route("GetAllOrder/{CurPage}/{TakeRows}")]
        [HttpGet]
        public async Task<ActionResult<List<VmOrder>>> GetAllOrder(int CurPage, int TakeRows)
        {
            return Ok(await _orderService.GetAllOrder(CurPage, TakeRows));
        }
        [Route("UpdateOrder")]
        [HttpPost]
        public async Task<ActionResult<VmResponseMessage>> UpdateOrder(VmOrder vm)
        {
            return Ok(await _orderService.UpdateOrder(vm));
        }
        [Route("RemoveOrder/{id}")]
        [HttpDelete]
        public async Task<ActionResult<VmResponseMessage>> RemoveOrder(int id)
        {
            return Ok(await _orderService.RemoveOrder(id));
        }
    }
}
