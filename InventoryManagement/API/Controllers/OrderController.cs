using BAL.Interface;
using BOL;
using BOL.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderBAL _orderBAL;
        public OrderController(IOrderBAL orderBAL) {
            _orderBAL = orderBAL;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll(int pageNo, int pageSize, string name = "")
        {
            try
            {
                var result = await _orderBAL.GetAll(pageNo, pageSize, name);
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
        public async Task<IActionResult> Create([FromBody] OrderReq orderReq)
        {
            try
            {
                var result = await _orderBAL.Create(orderReq);
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
        public async Task<IActionResult> Update([FromBody] OrderUpdateDto orderUpdateDto, int id)
        {
            try
            {
                var result = await _orderBAL.Update(orderUpdateDto, id);
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
                var result = await _orderBAL.Get(id);
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
                var result = await _orderBAL.Delete(id);
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
