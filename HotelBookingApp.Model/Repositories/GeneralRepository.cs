using HotelBookingApp.Data.Data;
using HotelBookingApp.Data.Entities;
using HotelBookingApp.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApp.Data.Repositories;

public class GeneralRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
{
    private readonly HotelDataContext _context;
    private readonly DbSet<TEntity> _dbSet;
    public GeneralRepository(HotelDataContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }
    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public virtual async Task<TEntity> GetByIdAsync(int id)
    {
        return await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
    }

    public virtual async Task<bool> AddAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
        return await _context.SaveChangesAsync() > 0;
    }

    public virtual async Task<bool> UpdateAsync(TEntity entity)
    {
        _dbSet.Update(entity);
        return await _context.SaveChangesAsync() > 0;
    }

    public virtual async Task<bool> DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        _dbSet.Remove(entity);
        return await _context.SaveChangesAsync() > 0;
    }
}