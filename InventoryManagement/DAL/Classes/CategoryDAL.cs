using BOL;
using DAL.DBContext;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Classes
{
    public class CategoryDAL : ICategoryDAL
    {
        private readonly DALDbContext _dALDbContext;
        public CategoryDAL( DALDbContext dALDbContext) {
        
            _dALDbContext = dALDbContext;
        }

        public async Task<List<Category>> GetAll()
        {
            try
            {
                return await _dALDbContext.categories.OrderBy(x => x.Name).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Category> Create(Category category)
        {
            try
            {
                await _dALDbContext.categories.AddAsync(category);
                await _dALDbContext.SaveChangesAsync();
                return category;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Category> Update(Category category)
        {
            try
            {
                _dALDbContext.categories.Update(category);
                await _dALDbContext.SaveChangesAsync();
                return category;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Category> GetByExpression(Expression<Func<Category, bool>> predicate)
        {
            try
            {
                return await _dALDbContext.Set<Category>().Where(predicate).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Items>> getItemsList()
        {
            try
            {
                return await _dALDbContext.items.OrderBy(x => x.Id).ToListAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
