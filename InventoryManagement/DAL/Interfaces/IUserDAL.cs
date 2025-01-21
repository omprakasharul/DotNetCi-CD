using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUserDAL
    {
        Task<Tuple<List<Users>, int>> GetAll(int pageNo, int pageSize);
        Task<Users> GetByExpression(Expression<Func<Users, bool>> predicate);
        Task<Users> Create(Users user);
        Task<Users> Update(Users user);
    }
}
