using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Vacation.DataAccess.Data;
using Vacation.DataAccess.IRepositories;

namespace Vacation.DataAccess.Repositories
{
    public class Repository<T>:IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> _dbSet;
        public Repository(ApplicationDbContext db)
        {
            _db = db;
            _dbSet = _db.Set<T>();
        }
        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string IncludeProperties = null)
        {
            try
            {
                IQueryable<T> query = _dbSet;
                if (filter != null)
                {
                    query = query.Where(filter);
                }
                if (IncludeProperties != null)
                {
                    foreach (var IncludeProp in IncludeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        query = query.Include(IncludeProp);
                    }
                }
                if (orderBy != null)
                {
                    return await orderBy(query).ToListAsync();
                }
                return await query.ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<T> GetFirstOrDefault(Expression<Func<T, bool>> filter = null, string IncludeProperties = null)
        {
            IQueryable<T> query = _dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (IncludeProperties != null)
            {
                foreach (var IncludeProp in IncludeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(IncludeProp);
                }
            }
            return await query.FirstOrDefaultAsync();
        }
        public IQueryable<T> GetAllAsQueryable()
        {
            IQueryable<T> query = _dbSet;

            return query.AsNoTracking();
        }

        public async Task<bool> Add(T entity)
        {
            try
            {
                await _db.AddAsync(entity);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> AddRange(List<T> Entities)
        {
            try
            {
                await _db.AddRangeAsync(Entities);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> Update(T entity)
        {
            try
            {
                _db.Entry(entity).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> Delete(T entity)
        {
            try
            {
                _db.Remove(entity);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<bool> DeleteRange(List<T> entities)
        {
            try
            {
                _db.RemoveRange(entities);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
