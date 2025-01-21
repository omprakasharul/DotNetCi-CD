using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Interface
{
    public interface IInventoryBAL
    {
        Task<ListResult<List<Inventory>>> GetAll(int pageNo, int pageSize, string sku, int itemId, int categoryId);
        Task<Result<Inventory>> Create(Inventory inventory);
        Task<Result<Inventory>> Get(int inventoryId);
        Task<Result<Inventory>> Update(Inventory inventory);
        Task<Result<string>> Delete(int inventoryId);
    }
}
