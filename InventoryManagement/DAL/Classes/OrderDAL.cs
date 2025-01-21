using Azure;
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
    public class OrderDAL : IOrderDAl
    {
        private readonly DALDbContext _dALDbContext;
        public OrderDAL(DALDbContext dALDbContext)
        {

            _dALDbContext = dALDbContext;
        }

        public async Task<Tuple<List<Order>, int>> GetAll(int pageNo, int pageSize, string name)
        {
            try
            {
                var query = _dALDbContext.orders.AsQueryable();

                if (!string.IsNullOrEmpty(name))
                {
                    query = query.Where(x => EF.Functions.Like(x.CustomerName, $"%{name}%"));
                }

                query = query.Where(x => x.IsActive);

                var totalCount = await query.CountAsync();

                var inventoryResult = await query
                    .Include(x => x.OrderItems)
                    .ThenInclude(x => x.Inventory)
                    .OrderByDescending(x => x.CreatedDate)
                    .Skip((pageNo - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                return new Tuple<List<Order>, int>(inventoryResult, totalCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Order> Create(Order order)
        {
            try
            {
                await _dALDbContext.orders.AddAsync(order);
                await _dALDbContext.SaveChangesAsync();
                return order;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Order> Update(Order order)
        {
            try
            {
                _dALDbContext.orders.Update(order);
                await _dALDbContext.SaveChangesAsync();
                return order;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Order> GetByExpression(int id)
        {
            try
            {
                return await _dALDbContext.orders
                    .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Inventory)
                .FirstOrDefaultAsync(o => o.Id == id);;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
