using HotelBookingApp.Data.Models;

namespace HotelBookingApp.Data.Interfaces;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetAllAsync();
    Task<User> GetByIdAsync(int id);
    Task<bool> AddAsync(User entity);
    Task<bool> UpdateAsync(User entity);
    Task<bool> DeleteAsync(int id);
}