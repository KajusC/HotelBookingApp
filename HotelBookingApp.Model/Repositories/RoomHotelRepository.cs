using HotelBookingApp.Data.Data;
using HotelBookingApp.Data.Entities.ManyToMany;
using HotelBookingApp.Data.Interfaces.ManyToMany;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApp.Data.Repositories;

public class RoomHotelRepository : GeneralRepository<RoomHotel>, IRoomHotelRepository
{
    public RoomHotelRepository(HotelDataContext context) : base(context)
    {
    }

    public override async Task<IEnumerable<RoomHotel>> GetAllAsync()
    {
        return await _dbSet
                .Include(rh => rh.Room)
                .Include(rh => rh.Hotel)
            .ToListAsync();
    }

    public override async Task<RoomHotel> GetByIdAsync(int id)
    {
        return await _dbSet
                .Include(rh => rh.Room)
                .Include(rh => rh.Hotel)
            .FirstOrDefaultAsync(rh => rh.Id == id);
    }
}