using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using ZeusERP.Core.Entities;

namespace ZeusERP.Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        IList<T> GetList(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter = null);
        int Add(T entity);
        int Update(T entity);
        int Delete(T entity);
        // Async Operations
        Task<IList<T>> GetListAsync(Expression<Func<T, bool>> filter = null);
        Task<T> GetAsync(Expression<Func<T, bool>> filter = null);
        Task<int> AddAsync(T entity);
        Task<int> UpdateAsync(T entity);
        Task<int> DeleteAsync(T entity);
    }
}
