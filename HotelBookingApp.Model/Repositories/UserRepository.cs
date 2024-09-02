using HotelBookingApp.Data.Data;
using HotelBookingApp.Data.Interfaces;
using HotelBookingApp.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApp.Data.Repositories;

public class UserRepository : IUserRepository
{
    private readonly UserManager<User> _userManager;

    public UserRepository(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _userManager.Users.ToListAsync();
    }

    public async Task<User> GetByIdAsync(int id)
    {
        return await _userManager.Users.FirstOrDefaultAsync(x => x.Id == id) ?? throw new ArgumentException("User with this id does not exist");
    }

    public async Task<bool> AddAsync(User entity)
    {
        var success = await _userManager.CreateAsync(entity);
        return success.Succeeded;
    }

    public async Task<bool> UpdateAsync(User entity)
    {
       var success = await _userManager.UpdateAsync(entity);
       return success.Succeeded;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var customer = await GetByIdAsync(id);
        var success = await _userManager.DeleteAsync(customer);
        return success.Succeeded;
    }
}