using BAL.Interface;
using BOL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBAL _userBAL;

        public UserController(IUserBAL userBAL)
        {
            _userBAL = userBAL;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int pageNo, int pageSize)
        {
            try
            {
                var result = await _userBAL.GetAll(pageNo, pageSize);
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
        public async Task<IActionResult> Create([FromBody] Users users)
        {
            try
            {
                var result = await _userBAL.Create(users);
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
        public async Task<IActionResult> Update([FromBody] Users users)
        {
            try
            {
                var result = await _userBAL.Update(users);
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
        public async Task<IActionResult> Get([FromQuery] string id)
        {
            try
            {
                var result = await _userBAL.Get(id);
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
        public async Task<IActionResult> Delete([FromQuery] string userId)
        {
            try
            {
                var result = await _userBAL.Delete(userId);
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
