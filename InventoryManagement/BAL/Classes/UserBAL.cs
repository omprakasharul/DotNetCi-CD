using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Azure.Identity;
using BAL.Common;
using BAL.Interface;
using BOL;
using DAL;
using DAL.Interfaces;

namespace BAL.Classes
{
    public class UserBAL : IUserBAL
    {
        private readonly IUserDAL _userDAL;
        private readonly LoginMethods _loginMethods;
        public UserBAL( IUserDAL userDAL, LoginMethods loginMethods)
        {
            _userDAL = userDAL;
            _loginMethods = loginMethods;
        }

        public async Task<ListResult<List<Users>>> GetAll(int pageNo, int pageSize)
        {
            try
            {
                var resultModel = new ListResult<List<Users>>();
                var result = await _userDAL.GetAll(pageNo, pageSize);
                if (result != null) {
                    resultModel.Data = result.Item1;
                    resultModel.TotalCount = result.Item2;
                    resultModel.Message = Resource.List;
                    resultModel.Success = true;
                }
                else
                {
                    resultModel.Success = false;
                    resultModel.Message = "Users Record is not retrieved";
                }
                return resultModel;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Result<Users>> Create(Users users)
        {
            var userModel = new Result<Users>();
            try
            {
                var userDetail = await _userDAL.GetByExpression(x => x.Email == users.Email);
                if (userDetail == null)
                {
                    users.Id = Convert.ToString(Guid.NewGuid);
                    users.UserName = string.Concat(users.FirstName + " " + users.LastName);
                    users.Password = _loginMethods.ConvertEncrypt(users.Password);
                    users.CreatedDate = DateTime.UtcNow;
                    users.UpdatedDate = DateTime.UtcNow;
                    users.IsActive = true;
                    users.IsDelete = false;

                    var result = await _userDAL.Create(users);

                    userModel.Data = result;
                    userModel.Success = true;
                    userModel.Message = Resource.Create;
                }
                else
                {
                    userModel.Success = false;
                    userModel.Message = "Email already exists";
                    userModel.Data = null;
                }
                return userModel;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Result<Users>> Get(string userId)
        {
            try
            {
                var userModel = new Result<Users>();
                var user = await _userDAL.GetByExpression(x => x.Id == userId && x.IsActive == true);
                if (user != null)
                {
                    userModel.Data = user;
                    userModel.Success = true;
                    userModel.Message = Resource.Get;
                }
                else
                {
                    userModel.Success= false;
                    userModel.Message = "Id is not valid";
                    userModel.Data = null;
                }
                return userModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Result<Users>> Update(Users users)
        {
            try
            {
                var userModel = new Result<Users>();
                var user = await _userDAL.GetByExpression(x => x.Id == users.Id && x.IsActive == true);
                if (user != null)
                {
                    user.FirstName = users.FirstName;
                    user.LastName = users.LastName;
                    user.Street = users.Street;
                    user.City = users.City;
                    user.ZipCode = users.ZipCode;
                    user.Country = users.Country;
                    user.MobileNumber = users.MobileNumber;
                    user.Status = users.Status;
                    user.IsDelete = users.IsDelete;
                    user.IsActive = users.IsActive;
                    user.UserName = string.Concat(users.FirstName + " " + users.LastName);
                    user.UpdatedBy = users.UpdatedBy;
                    user.UpdatedDate = DateTime.UtcNow;

                    var userObj = await _userDAL.Update(user);

                    userModel.Success = true;
                    userModel.Data = userObj;
                    userModel.Message = Resource.Update;
                }
                else
                {
                    userModel.Success = false;
                    userModel.Message = "Record is not retrieved check ID";
                    userModel.Data = null;
                }
                return userModel;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Result<string>> Delete(string userId)
        {
            try
            {
                var resultModel = new Result<string>();
                var deletedUser = await _userDAL.GetByExpression(x => x.Id == userId && x.IsActive == true);
                if (deletedUser != null)
                {
                    deletedUser.IsActive = false;
                    deletedUser.IsDelete = true;
                    var result = await _userDAL.Update(deletedUser);
                    resultModel.Message = Resource.Delete;
                    resultModel.Success = true;
                }
                else
                {
                    resultModel.Message = "Id is not valid";
                    resultModel.Success = false;
                }
                return resultModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
