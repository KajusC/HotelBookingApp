using HotelBookingApp.Data.Data;
using HotelBookingApp.Data.Interfaces;
using HotelBookingApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApp.Data.Repositories;

public class FoodRepository : IFoodRepository
{
    private readonly DbSet<Food> _foods;
    private readonly HotelDataContext _hotelDataContext;

    public FoodRepository(HotelDataContext hotelDataContext)
    {
        _hotelDataContext = hotelDataContext;
        _foods = hotelDataContext.Foods;
    }
    public async Task<IEnumerable<Food>> GetAllAsync()
    {
        return await _foods.ToListAsync();
    }

    public async Task<Food> GetByIdAsync(int id)
    {
        return await _foods.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<bool> AddAsync(Food entity)
    {
        await _foods.AddAsync(entity);
        return await _hotelDataContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> UpdateAsync(Food entity)
    {
        _foods.Update(entity);
        return await _hotelDataContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var food = await GetByIdAsync(id);
        _foods.Remove(food);
        return await _hotelDataContext.SaveChangesAsync() > 0;
    }
}