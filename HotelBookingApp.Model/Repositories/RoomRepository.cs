using HotelBookingApp.Data.Data;
using HotelBookingApp.Data.Interfaces;
using HotelBookingApp.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApp.Data.Repositories;

public class RoomRepository : GeneralRepository<Room>, IRoomRepository
{
    public RoomRepository(HotelDataContext context) : base(context)
    {
    }

    public override async Task<IEnumerable<Room>> GetAllAsync()
    {
        return await _dbSet
            .Include(r => r.RoomOrders)
            .ToListAsync();
    }
    public override async Task<Room> GetByIdAsync(int id)
    {
        return await _dbSet
            .Include(r => r.RoomOrders)
            .FirstOrDefaultAsync(r => r.Id == id);
    }
}