using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IInventoryDAL
    {
        Task<Tuple<List<Inventory>, int>> GetAll(int pageNo, int pageSize, string sku, int itemId, int categoryId);
        Task<Inventory> GetByExpression(Expression<Func<Inventory, bool>> predicate);
        Task<Inventory> Create(Inventory inventory);
        Task<Inventory> Update(Inventory inventory);
    }
}
