using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Application.Interfaces.IServices;
using OrderManagement.Application.Services;
using OrderManagement.Application.ViewModel;

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
        public async Task<ActionResult<List<VmOrder>>> GetAllSupplier()
        {
            return Ok(await _supplierService.GetAllSupplier());
        }
    }
}
