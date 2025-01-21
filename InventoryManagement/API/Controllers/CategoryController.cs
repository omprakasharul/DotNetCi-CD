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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryBAL _categoryBAL;
        public CategoryController(ICategoryBAL categoryBAL) {
            _categoryBAL = categoryBAL;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _categoryBAL.GetAll();
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
        public async Task<IActionResult> Create([FromBody] Category category)
        {
            try
            {
                var result = await _categoryBAL.Create(category);
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
        public async Task<IActionResult> Update([FromBody] Category category)
        {
            try
            {
                var result = await _categoryBAL.Update(category);
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
                var result = await _categoryBAL.Get(id);
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
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            try
            {
                var result = await _categoryBAL.Delete(id);
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

        [HttpGet("ItemList")]
        public async Task<IActionResult> GetItemList()
        {
            try
            {
                var result = await _categoryBAL.getItemList();
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
