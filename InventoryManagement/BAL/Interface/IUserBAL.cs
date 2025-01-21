using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Interface
{
    public interface IUserBAL
    {
        Task<ListResult<List<Users>>> GetAll(int pageNo, int pageSize);
        Task<Result<Users>> Create(Users users);
        Task<Result<Users>> Get(string userId);
        Task<Result<Users>> Update(Users users);
        Task<Result<string>> Delete(string userId);
    }
}
