using Microsoft.AspNetCore.Mvc;
using OrderManagement.Application.Interfaces.IServices;
using OrderManagement.Domain.Entities;

namespace OrderManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _supplierService;
        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }
        [Route("GetAllSupplier")]
        [HttpGet]
        public async Task<ActionResult<List<Supplier>>> GetAllSupplier()
        {
            return Ok(await _supplierService.GetAllSupplier());
        }
    }
}
