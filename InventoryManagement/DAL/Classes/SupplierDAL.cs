using BOL;
using DAL.DBContext;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Classes
{
    public class SupplierDAL : ISupplierDAL
    {
        private readonly DALDbContext _dALDbContext;
        public SupplierDAL(DALDbContext dALDbContext) { 
            _dALDbContext = dALDbContext;
        }

        public async Task<List<Supplier>> GetAll()
        {
            try
            {
                return await _dALDbContext.suppliers.OrderBy(x => x.Name).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Supplier> Create(Supplier supplier)
        {
            try
            {
                await _dALDbContext.suppliers.AddAsync(supplier);
                await _dALDbContext.SaveChangesAsync();
                return supplier;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Supplier> Update(Supplier supplier)
        {
            try
            {
                _dALDbContext.suppliers.Update(supplier);
                await _dALDbContext.SaveChangesAsync();
                return supplier;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Supplier> GetByExpression(Expression<Func<Supplier, bool>> predicate)
        {
            try
            {
                return await _dALDbContext.Set<Supplier>().Where(predicate).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
