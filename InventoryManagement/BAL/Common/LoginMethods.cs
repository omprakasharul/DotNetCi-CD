using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Common
{
    public class LoginMethods
    {
        private readonly IConfiguration _configuration;
        public LoginMethods(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // Password Encryption
        public string ConvertEncrypt(string Password)
        {
            if (string.IsNullOrEmpty(Password)) return "";
            Password += _configuration.GetSection("Jwt:Key").Value;
            var passwordbytes = Encoding.UTF8.GetBytes(Password);
            return Convert.ToBase64String(passwordbytes);
        }

        // Password Decryption
        public string ConvertDecrypt(string Password)
        {
            if (string.IsNullOrEmpty(Password)) return "";

            var passwordbytes = Convert.FromBase64String(Password);
            var result = Encoding.UTF8.GetString(passwordbytes);
            result = result.Substring(0, result.Length - _configuration.GetSection("Jwt:Key").Value.Length);
            return result;
        }

        internal string GenerateJwtToken(string userName, string roleName)
        {
            try
            {
                var key = _configuration.GetSection("Jwt:SaltKey").Value;
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "YourIssuer",
                    audience: "YourAudience",
                    claims: new[] { new Claim(ClaimTypes.Name, userName),
                    new Claim(ClaimTypes.Role, roleName)},
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: credentials);

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
