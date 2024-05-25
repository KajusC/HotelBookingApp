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

    public async Task AddAsync(Food entity)
    {
        await _foods.AddAsync(entity);
        await _hotelDataContext.SaveChangesAsync();
    }

    public async Task Delete(Food entity)
    {
        _foods.Remove(entity);
        await _hotelDataContext.SaveChangesAsync();
    }

    public async Task DeleteByIdAsync(int id)
    {
        var food = await GetByIdAsync(id);
        if (food == null) return;

        _foods.Remove(food);
        await _hotelDataContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Food entity)
    {
        _foods.Update(entity);
        await _hotelDataContext.SaveChangesAsync();
    }

    public async Task<Food> GetFoodsWithDetailsAsync()
    {
        return await _foods
            .Include(f => f.Hotels)
            .Include(f => f.Orders)
            .FirstOrDefaultAsync();
    }

    public async Task<Food> GetFoodWithDetailsAsyncById(int id)
    {
        return await _foods
            .Include(f => f.Hotels)
            .Include(f => f.Orders)
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}
