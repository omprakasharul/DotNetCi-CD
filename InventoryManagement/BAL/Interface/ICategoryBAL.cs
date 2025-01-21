using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Interface
{
    public interface ICategoryBAL
    {
        Task<Result<List<Category>>> GetAll();
        Task<Result<Category>> Create(Category category);
        Task<Result<Category>> Update(Category category);
        Task<Result<Category>> Get(int categoryId);
        Task<Result<string>> Delete(int categoryId);
        Task<ListResult<List<Items>>> getItemList();
    }
}
