using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TiSupport.DataAccess.Database;
using TiSupport.DataAccess.Repository.IRepo;

namespace TiSupport.DataAccess.Repository;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly DbSet<T> _dbSet;

    public Repository(AppDbContext db)
    {
        _dbSet = db.Set<T>();
    }

    public async Task<T> Add(T entity)
    {
        await _dbSet.AddAsync(entity);
        return entity;
    }

    public async Task<IEnumerable<T>> AddRange(IEnumerable<T> entities)
    {
        IEnumerable<T> addRange = entities.ToList();
        await _dbSet.AddRangeAsync(addRange);
        return addRange;
    }

    public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
    {
        IQueryable<T> query = _dbSet;
        if (filter != null)
        {
            query = query.Where(filter);
        }
        if (includeProperties != null)
        {
            for (var index = 0;
                 index < includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Length;
                 index++)
            {
                var includeProp =
                    includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)[index];
                query = query.Include(includeProp);
            }
        }
        await query.ToListAsync();
        return query;
    }

    public async Task<T?> GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includeProperties = null, bool tracked = true)
    {
        IQueryable<T> query = tracked ? _dbSet : _dbSet.AsNoTracking();

        query = query.Where(filter);

        if (includeProperties == null) return await query.FirstOrDefaultAsync();
        query = includeProperties
            .Split([','], StringSplitOptions.RemoveEmptyEntries)
            .Aggregate(query, (current, includeProp) => current
                .Include(includeProp));

        return await query.FirstOrDefaultAsync();
    }

    public async Task Remove(T entity)
    {
        await Task.FromResult(_dbSet.Remove(entity));
    }

    public void RemoveRange(IEnumerable<T> entity)
    {
        _dbSet.RemoveRange(entity);
    }
}