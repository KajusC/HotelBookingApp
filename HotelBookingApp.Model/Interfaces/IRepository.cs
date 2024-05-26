using HotelBookingApp.Data.Entities;

namespace HotelBookingApp.Data.Interfaces;

public interface IRepository<TEntity> where TEntity : BaseEntity
{
    Task<IEnumerable<TEntity>> GetAllAsync();

    Task<TEntity> GetByIdAsync(int id);

    Task AddAsync(TEntity entity);

    Task DeleteAsync(TEntity entity);

    Task DeleteByIdAsync(int id);

    Task UpdateAsync(TEntity entity);

    Task SaveChangesAsync();
}