using HotelBookingApp.Data.Data;
using HotelBookingApp.Data.Entities;
using HotelBookingApp.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HotelBookingApp.Data.Repositories;

public class GeneralRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
{
    protected readonly HotelDataContext _context;
    protected readonly DbSet<TEntity> _dbSet;
    public GeneralRepository(HotelDataContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }
    public virtual async Task<TEntity> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public virtual async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _dbSet.SingleOrDefaultAsync(predicate) ?? throw new ArgumentException("Entity with this predicate does not exist");
    }

    public virtual async Task AddAsync(TEntity entity)
    {
        // Ensure the entity is not already being tracked to prevent duplication
        var entry = _context.Entry(entity);
        if (entry.State == EntityState.Detached)
        {
            await _dbSet.AddAsync(entity);
        }
        await _context.SaveChangesAsync();
    }

    public virtual async Task UpdateAsync(TEntity entity)
    {
        _dbSet.Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public virtual async Task DeleteAsync(TEntity entity)
    {
        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
    }
    
    public virtual async Task DeleteByIdAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _dbSet.Remove(entity);
        }
        await _context.SaveChangesAsync();
    }

    public virtual async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}