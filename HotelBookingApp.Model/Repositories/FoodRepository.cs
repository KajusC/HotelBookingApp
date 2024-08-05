using HotelBookingApp.Data.Data;
using HotelBookingApp.Data.Entities;
using HotelBookingApp.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApp.Data.Repositories;

public class FoodRepository : GeneralRepository<Food>, IFoodRepository
{
    public FoodRepository(HotelDataContext context) : base(context)
    {
    }

    public override async Task<IEnumerable<Food>> GetAllAsync()
    {
        var list = await _dbSet
            .Include(f => f.FoodHotels)
            .ThenInclude(f => f.Hotel)
            .Include(f => f.FoodOrders)
            .ToListAsync();

        foreach (var food in list)
        {
            food.Name = food.Name.ToLower();
        }
        return list;
    }

    public override async Task<Food> GetByIdAsync(int id)
    {
        return await _dbSet
            .Include(f => f.FoodHotels)
            .ThenInclude(f => f.Hotel)
            .Include(f => f.FoodOrders)
            .FirstOrDefaultAsync(f => f.Id == id) ?? throw new ArgumentException("Food with this id does not exist");
    }
}