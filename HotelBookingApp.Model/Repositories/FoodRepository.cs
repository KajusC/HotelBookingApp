using HotelBookingApp.Data.Data;
using HotelBookingApp.Data.Interfaces;
using HotelBookingApp.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApp.Data.Repositories;

public class FoodRepository : GeneralRepository<Food>, IFoodRepository
{
    public FoodRepository(HotelDataContext context) : base(context)
    {
    }

    public override async Task<IEnumerable<Food>> GetAllAsync()
    {
        return await _dbSet
            .Include(f => f.FoodHotels)
            .Include(f => f.FoodOrders)
            .ToListAsync();
    }
    public override async Task<Food> GetByIdAsync(int id)
    {
        return await _dbSet
            .Include(f => f.FoodHotels)
            .Include(f => f.FoodOrders)
            .FirstOrDefaultAsync(f => f.Id == id);
    }
}