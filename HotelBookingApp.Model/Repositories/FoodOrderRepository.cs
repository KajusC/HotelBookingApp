using HotelBookingApp.Data.Data;
using HotelBookingApp.Data.Entities.ManyToMany;
using HotelBookingApp.Data.Interfaces.ManyToMany;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApp.Data.Repositories;

public class FoodOrderRepository : GeneralRepository<FoodOrder>, IFoodOrderRepository
{
    public FoodOrderRepository(HotelDataContext context) : base(context)
    {
    }

    public override async Task<IEnumerable<FoodOrder>> GetAllAsync()
    {
        return await _dbSet
            .Include(fo => fo.Food)
            .Include(fo => fo.Order)
            .ToListAsync();
    }

    public override async Task<FoodOrder> GetByIdAsync(int id)
    {
        return await _dbSet
            .Include(fo => fo.Food)
            .Include(fo => fo.Order)
            .FirstOrDefaultAsync(fo => fo.Id == id);
    }
}
