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
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryBAL _inventoryBAL;

        public InventoryController(IInventoryBAL inventoryBAL)
        {
            _inventoryBAL = inventoryBAL;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int pageNo, int pageSize, string sku = "", int itemId = 0, int categorId = 0)
        {
            try
            {
                var result = await _inventoryBAL.GetAll(pageNo, pageSize, sku, itemId, categorId);
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
        public async Task<IActionResult> Create([FromBody] Inventory inventory)
        {
            try
            {
                var result = await _inventoryBAL.Create(inventory);
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
        public async Task<IActionResult> Update([FromBody] Inventory inventory)
        {
            try
            {
                var result = await _inventoryBAL.Update(inventory);
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
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var result = await _inventoryBAL.Get(id);
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _inventoryBAL.Delete(id);
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
