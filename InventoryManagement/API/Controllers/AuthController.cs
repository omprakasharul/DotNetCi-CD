using BAL.Interface;
using BOL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthAccess _authAccess;

        public AuthController(IAuthAccess authAccess)
        {
            _authAccess = authAccess;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginReq model)
        {
            try
            {
                var result = await _authAccess.AuthLogin(model);
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
