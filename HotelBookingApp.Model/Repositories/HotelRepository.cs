using HotelBookingApp.Data.Data;
using HotelBookingApp.Data.Interfaces;
using HotelBookingApp.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApp.Data.Repositories;

public class HotelRepository : GeneralRepository<Hotel>, IHotelRepository
{
    public HotelRepository(HotelDataContext context) : base(context)
    {
    }

    public override async Task<IEnumerable<Hotel>> GetAllAsync()
    {
        return await _dbSet
            .Include(h => h.RoomHotels)
            .Include(h => h.FoodHotels)
            .Include(h => h.Orders)
            .ToListAsync();
    }

    public override async Task<Hotel> GetByIdAsync(int id)
    {
        return await _dbSet
            .Include(h => h.RoomHotels)
            .Include(h => h.FoodHotels)
            .Include(h => h.Orders)
            .FirstOrDefaultAsync(h => h.Id == id);
    }
}