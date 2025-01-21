using BAL.Common;
using BAL.Interface;
using BOL;
using DAL.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Classes
{
    public class AuthAccess : IAuthAccess
    {
        private readonly DALDbContext _dalDBContext;
        private readonly IConfiguration _configuration;
        private readonly LoginMethods _loginMethods;

        public AuthAccess(DALDbContext dALDbContext, IConfiguration configuration, LoginMethods loginMethods)
        {
            _dalDBContext = dALDbContext;
            _configuration = configuration;
            _loginMethods = loginMethods;
        }

        public async Task<Result<LoginRes>> AuthLogin(LoginReq login)
        {
            try
            {
                var resultModel = new Result<LoginRes>();
                var loginRes = new LoginRes();
                var encryptPassword = _loginMethods.ConvertEncrypt(login.LoginPassword);
                var user = await _dalDBContext.users.Include("Role")
                    .Where(x => x.Email == login.LoginEmail && x.IsActive == true && x.Password == encryptPassword)
                    .FirstOrDefaultAsync();
                if(user != null)
                {
                    loginRes.Token = _loginMethods.GenerateJwtToken(user.Email, user.Role.RoleName);
                    loginRes.Users = user;
                    resultModel.Data = loginRes;
                    resultModel.Success = true;
                    resultModel.Message = Resource.Success;
                }
                else
                {
                    resultModel.Data = null;
                    resultModel.Success = false;
                    resultModel.Message = "Check username and Password";
                }
                return resultModel;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
