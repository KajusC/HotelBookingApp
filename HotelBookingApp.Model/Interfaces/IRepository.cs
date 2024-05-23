using HotelBookingApp.Data.Models;

namespace HotelBookingApp.Data.Interfaces;

public interface IRepository<TEntity> where TEntity : BaseEntity
{
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<TEntity> GetByIdAsync(int id);
    Task<bool> AddAsync(TEntity entity);
    Task<bool> UpdateAsync(TEntity entity);
    Task<bool> DeleteAsync(int id);
}