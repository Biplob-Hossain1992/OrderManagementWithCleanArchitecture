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
            //var list = new List<VmTableValuedParameter>();
            //var model = new VmOrder
            //{
            //    ReferenceId = 001,
            //    OrderNo = "1001",
            //    OrderDateString = DateTime.Now.ToString(),
            //    SupplierId = 1,
            //    ExpectedDateString = DateTime.Now.ToString(),
            //    Remarks = "Create Order"
            //};
            //for (int i = 0; i < 3; i++)
            //{
            //    var orderItem = new VmTableValuedParameter
            //    {
            //        OrderId = 1,
            //        ItemId = i + 1,
            //        Quantity = 5 + i,
            //        Rate = 12 + i
            //    };
            //    list.Add(orderItem);
            //}
            //model.OrderItem = list;
            return Ok(await _orderService.CreateOrder(vm));
        }
        [Route("GetById")]
        [HttpGet]
        public async Task<ActionResult<Order>> GetById(int id)
        {
            return Ok(await _orderService.GetById(id));
        }
        [Route("GetAllOrder")]
        [HttpGet]
        public async Task<ActionResult<List<VmOrder>>> GetAllOrder()
        {
            return Ok(await _orderService.GetAllOrder());
        }
        [Route("UpdateOrder")]
        [HttpPost]
        public async Task<ActionResult<VmResponseMessage>> UpdateOrder(VmOrder vm)
        {
            //var list = new List<VmTableValuedParameter>();
            //var model = new VmOrder
            //{
            //    Id = 2,
            //    OrderNo = "1002",
            //    OrderDateString = DateTime.Now.AddDays(1).ToString(),
            //    SupplierId = 1,
            //    ExpectedDateString = DateTime.Now.AddDays(1).ToString(),
            //    Remarks = "Update Order"
            //};
            //for (int i = 0; i < 3; i++)
            //{
            //    var orderItem = new VmTableValuedParameter
            //    {
            //        OrderId = 2,
            //        ItemId = i + 2,
            //        Quantity = 15 + i,
            //        Rate = 100 + i
            //    };
            //    list.Add(orderItem);
            //}
            //model.OrderItem = list;
            return Ok(await _orderService.UpdateOrder(vm));
        }
        [Route("RemoveOrder")]
        [HttpDelete]
        public async Task<ActionResult<VmResponseMessage>> RemoveOrder(int id)
        {
            return Ok(await _orderService.RemoveOrder(id));
        }
    }
}
