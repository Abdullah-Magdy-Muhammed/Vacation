using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Vacation.DataAccess.IRepositories
{
    public interface IRepository<T> where T : class
    {
        #region GetAll
        Task<IEnumerable<T>> GetAll(
                Expression<Func<T, bool>> filter = null,
                Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                string IncludeProperties = null
            );
        #endregion
        #region GetAllAsQue
        IQueryable<T> GetAllAsQueryable();

        #endregion
        #region GetOne
        Task<T> GetFirstOrDefault(
            Expression<Func<T, bool>> filter = null,
            string IcludeProperties = null
            );
        #endregion
        #region AddOne
        Task<bool> Add(T entity);
        #endregion
        #region AddRange
        Task<bool> AddRange(List<T> entities);

        #endregion
        #region UpdateOne
        Task<bool> Update(T entity);

        #endregion
        #region DeleteOne
        Task<bool> Delete(T entity);

        #endregion
        #region DeleteRange
        Task<bool> DeleteRange(List<T> entities);

        #endregion
    }
}
