using BAL.Interface;
using BOL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierBAL _supplierBAL;
        public SupplierController(ISupplierBAL supplierBAL)
        {
            _supplierBAL = supplierBAL;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _supplierBAL.GetAll();
                if (result.Success)
                {
                    return Ok(result);
                }
                else
                {
                    return StatusCode(400, result);
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Supplier supplier)
        {
            try
            {
                var result = await _supplierBAL.Create(supplier);
                if (result.Success)
                {
                    return StatusCode(200, result);
                }
                else
                {
                    return StatusCode(400, result);
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }

        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Supplier supplier)
        {
            try
            {
                var result = await _supplierBAL.Update(supplier);
                if (result.Success)
                {
                    return StatusCode(200, result);
                }
                else
                {
                    return StatusCode(400, result);
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromQuery] int id)
        {
            try
            {
                var result = await _supplierBAL.Get(id);
                if (result.Success)
                {
                    return StatusCode(200, result);
                }
                else
                {
                    return StatusCode(400, result);
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }

        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int supplierId)
        {
            try
            {
                var result = await _supplierBAL.Delete(supplierId);
                if (result.Success)
                {
                    return StatusCode(200, result);
                }
                else
                {
                    return StatusCode(400, result);
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }

        }
    }
}
