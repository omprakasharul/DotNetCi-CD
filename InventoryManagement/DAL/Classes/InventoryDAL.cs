using BOL;
using DAL.DBContext;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Classes
{
    public class InventoryDAL : IInventoryDAL
    {
        private readonly DALDbContext _dbContext;

        public InventoryDAL(DALDbContext dALDbContext)
        {
            _dbContext = dALDbContext;
        }

        public async Task<Tuple<List<Inventory>, int>> GetAll(int pageNo, int pageSize, string sku, int itemId, int categoryId)
        {
            try
            {
                var query = _dbContext.inventories.AsQueryable();

                if (!string.IsNullOrEmpty(sku))
                {
                    query = query.Where(x => EF.Functions.Like(x.SKU, $"%{sku}%"));
                }

                if (itemId != 0)
                {
                    query = query.Where(x => x.ItemId == itemId);
                }

                if (categoryId != 0)
                {
                    query = query.Where(x => x.CategoryId == categoryId);
                }

                query = query.Where(x => x.IsActive);

                var totalCount = await query.CountAsync();

                var inventoryResult = await query
                    .Include(x => x.Category)
                    .Include(x => x.Supplier)
                    .OrderByDescending(x => x.CreatedDate)
                    .Skip((pageNo - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                return new Tuple<List<Inventory>, int>(inventoryResult, totalCount);
            }
            catch (Exception ex)
            {
                // It's generally better to let the exception propagate rather than re-throwing it
                throw;
            }
        }

        public async Task<Inventory> GetByExpression(Expression<Func<Inventory, bool>> predicate)
        {
            try
            {
                return await _dbContext.Set<Inventory>().Where(predicate).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Inventory> Create(Inventory inventory)
        {
            try
            {
                var result = await _dbContext.Set<Inventory>().AddAsync(inventory);
                await _dbContext.SaveChangesAsync();
                return inventory;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Inventory> Update(Inventory inventory)
        {
            try
            {
                var Result = _dbContext.Set<Inventory>().Update(inventory);
                await _dbContext.SaveChangesAsync();
                return inventory;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
