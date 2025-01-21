using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IOrderDAl
    {
        Task<Tuple<List<Order>, int>> GetAll(int pageNo, int pageSize, string name);
        Task<Order> Create(Order order);
        Task<Order> Update(Order order);
        Task<Order> GetByExpression(int id);
    }
}
