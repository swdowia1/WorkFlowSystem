using System.Linq.Expressions;

namespace WorkFlowSystem.Application.Repositories
{
    public interface ILinkRepository<T>
    where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<IEnumerable<T>> FindAsync(
            Expression<Func<T, bool>> predicate);

        Task<T?> FirstOrDefaultAsync(
            Expression<Func<T, bool>> predicate);

        Task<bool> AnyAsync(
            Expression<Func<T, bool>> predicate);

        Task AddAsync(T entity);

        Task DeleteAsync(T entity);
    }
}
