using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WorkFlowSystem.Application.Repositories;
using WorkFlowSystem.Domain.Entities;
using WorkFlowSystem.Infrastructure.Persistence;

namespace WorkFlowSystem.Infrastructure.Infra
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
     {
        private readonly ApplicationDbContext _context;

        private readonly DbSet<T> _dbSet;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }
        public async Task<bool> AnyAsync(
       Expression<Func<T, bool>> predicate)
        {

            return await _dbSet
                .AnyAsync(predicate);

        }
        public async Task<T?> FirstOrDefaultAsync(
    Expression<Func<T, bool>> predicate)
        {
            return await _dbSet
                .FirstOrDefaultAsync(predicate);
        }

        public async Task<T?> GetAsync(
      int id,
      Func<IQueryable<T>, IQueryable<T>>? include = null)
        {
            IQueryable<T> query = _context.Set<T>();

            if (include != null)
            {
                query = include(query);
            }

            return await query.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);

            await Task.CompletedTask;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);

            if (entity != null)
                _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);

            await _context.SaveChangesAsync();
        }
        public async Task<List<T>> GetAllAsync(
    params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _context.Set<T>();

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.ToListAsync();
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
        public async Task<List<T>> GetAllAsyncWhereInlude(
    Expression<Func<T, bool>> predicate,
    params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _context.Set<T>();


            foreach (var include in includes)
            {
                query = query.Include(include);
            }


            if (predicate != null)
            {
                query = query.Where(predicate);
            }


            return await query.ToListAsync();
        }
    }
}
