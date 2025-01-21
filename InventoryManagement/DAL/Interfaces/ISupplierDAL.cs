using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ISupplierDAL
    {
        Task<Supplier> GetByExpression(Expression<Func<Supplier, bool>> predicate);
        Task<Supplier> Update(Supplier supplier);
        Task<Supplier> Create(Supplier supplier);
        Task<List<Supplier>> GetAll();
    }
}
