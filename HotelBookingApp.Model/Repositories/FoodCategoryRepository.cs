using HotelBookingApp.Model.Data;
using HotelBookingApp.Model.Interfaces;
using HotelBookingApp.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApp.Model.Repositories;

public class FoodCategoryRepository : IFoodCategoryRepository
{
    private readonly DbSet<FoodCategory> _foodCategories;
    private readonly HotelDataContext _hotelDataContext;
    public FoodCategoryRepository(HotelDataContext hotelDataContext)
    {
        _hotelDataContext = hotelDataContext;
        _foodCategories = hotelDataContext.FoodCategories;
    }

    public async Task<IEnumerable<FoodCategory>> GetAllAsync()
    {
        return await _foodCategories.ToListAsync();
    }

    public async Task<FoodCategory> GetByIdAsync(int id)
    {
        return await _foodCategories.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<bool> AddAsync(FoodCategory entity)
    {
        await _foodCategories.AddAsync(entity);
        return await _hotelDataContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> UpdateAsync(FoodCategory entity)
    {
        _foodCategories.Update(entity);
        return await _hotelDataContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var foodCategory = await GetByIdAsync(id);
        _foodCategories.Remove(foodCategory);
        return await _hotelDataContext.SaveChangesAsync() > 0;
    }
}