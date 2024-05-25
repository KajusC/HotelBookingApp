using HotelBookingApp.Data.Models;

namespace HotelBookingApp.Data.Interfaces;

public interface IRepository<TEntity> where TEntity : BaseEntity
{
    Task<IEnumerable<TEntity>> GetAllAsync();

    Task<TEntity> GetByIdAsync(int id);

    Task AddAsync(TEntity entity);

    Task Delete(TEntity entity);

    Task DeleteByIdAsync(int id);

    Task UpdateAsync(TEntity entity);
}