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
    public class UserDAL : IUserDAL
    {
        private readonly DALDbContext _dbContext;

        public UserDAL(DALDbContext dALDbContext)
        {
            _dbContext = dALDbContext;
        }

        public async Task<Tuple<List<Users>,int>> GetAll(int pageNo, int pageSize)
        {
            try
            {
                var usersResult = await _dbContext.users.Where(x => x.IsActive == true)
                    .OrderByDescending(x => x.CreatedDate)
                    .Skip((pageNo-1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();
                return new Tuple<List<Users>, int>(usersResult, usersResult.Count());
            }
            catch(Exception ex) 
            {
                throw ex;
            }
        }

        public async Task<Users> GetByExpression(Expression<Func<Users, bool>> predicate)
        {
            try
            {
                return await _dbContext.Set<Users>().Where(predicate).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Users> Create(Users user)
        {
            try
            {
                var result = await _dbContext.Set<Users>().AddAsync(user);
                await _dbContext.SaveChangesAsync();
                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Users> Update(Users User)
        {
            try
            {
                var Result = _dbContext.Set<Users>().Update(User);
                await _dbContext.SaveChangesAsync();
                return User;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
