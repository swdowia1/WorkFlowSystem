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

        Task<T?> GetByIdAsync(int id);
        Task<T?> GetAsync(
    int id,
    params Expression<Func<T, object>>[] includes);
        Task AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(int id);
 
        Task SaveChangesAsync();
        Task<List<T>> GetAllAsync(
    params Expression<Func<T, object>>[] includes);
        Task<List<T>> GetAllAsyncWhereInlude(
    Expression<Func<T, bool>> predicate,
    params Expression<Func<T, object>>[] includes);
    }
}
