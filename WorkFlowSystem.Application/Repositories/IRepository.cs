using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WorkFlowSystem.Application.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<bool> AnyAsync(
    Expression<Func<T, bool>> predicate);
        Task<T?> FirstOrDefaultAsync(
       Expression<Func<T, bool>> predicate);
        Task<T?> GetByIdAsync(int id);
        Task<T?> GetAsync(
            int id,
            Func<IQueryable<T>, IQueryable<T>>? include = null);
        Task AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(int id);
        Task DeleteAsync(T entity);

        Task SaveChangesAsync();
        Task<List<T>> GetAllAsync(
    params Expression<Func<T, object>>[] includes);
        Task<List<T>> GetAllAsyncWhereInlude(
    Expression<Func<T, bool>> predicate,
    params Expression<Func<T, object>>[] includes);
    }
}
