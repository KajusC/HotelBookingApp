using HotelBookingApp.Data.Data;
using HotelBookingApp.Data.Interfaces;
using HotelBookingApp.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApp.Data.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DbSet<User> _customerSet;
    private readonly HotelDataContext _context;


    public UserRepository(HotelDataContext dataContext)
    {
        _context = dataContext;
        _customerSet = dataContext.Users;
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _customerSet.ToListAsync();
    }

    public async Task<User> GetByIdAsync(int id)
    {

        return (await _customerSet.FirstOrDefaultAsync(x => x.Id == id));
    }

    public async Task<bool> AddAsync(User entity)
    {
        await _customerSet.AddAsync(entity);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> UpdateAsync(User entity)
    {
        _customerSet.Update(entity);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var customer = await GetByIdAsync(id);
        _customerSet.Remove(customer);
        return await _context.SaveChangesAsync() > 0;
    }
}