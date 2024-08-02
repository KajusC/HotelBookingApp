using HotelBookingApp.Data.Data;
using HotelBookingApp.Data.Entities;
using HotelBookingApp.Data.Entities.ManyToMany;
using HotelBookingApp.Data.Interfaces.ManyToMany;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApp.Data.Repositories;

public class FoodHotelRepository : GeneralRepository<FoodHotel>, IFoodHotelRepository
{
    public FoodHotelRepository(HotelDataContext context) : base(context)
    {
    }
    public override async Task<IEnumerable<FoodHotel>> GetAllAsync()
    {
        return await _dbSet
                .Include(fh => fh.Food)
                .Include(fh => fh.Hotel)
            .ToListAsync();
    }
    public override async Task<FoodHotel> GetByIdAsync(int id)
    {
        return await _dbSet
                .Include(fh => fh.Food)
                .Include(fh => fh.Hotel)
                .FirstOrDefaultAsync(fh => fh.Id == id);
    }

    public override async Task AddAsync(FoodHotel entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }
}
