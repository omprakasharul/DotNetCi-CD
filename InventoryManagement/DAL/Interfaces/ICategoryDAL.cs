using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ICategoryDAL
    {
        Task<Category> GetByExpression(Expression<Func<Category, bool>> predicate);
        Task<Category> Update(Category category);
        Task<Category> Create(Category category);
        Task<List<Category>> GetAll();
        Task<List<Items>> getItemsList();
    }
}
