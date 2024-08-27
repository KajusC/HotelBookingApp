using System.Dynamic;
using HotelBookingApp.Data.Data;
using HotelBookingApp.Data.Interfaces;
using HotelBookingApp.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApp.Data.Repositories;

public class RoomTypeRepository : GeneralRepository<RoomType>, IRoomTypeRepository
{
    public RoomTypeRepository(HotelDataContext context) : base(context)
    {
    }

    public override async Task<IEnumerable<RoomType>> GetAllAsync()
    {
        return await _dbSet
            .Include(rt => rt.Rooms)
            .ToListAsync();
    }
    public override async Task<RoomType> GetByIdAsync(int id)
    {
        return await _dbSet
            .Include(rt => rt.Rooms)
            .FirstOrDefaultAsync(rt => rt.Id == id) ?? throw new ArgumentException("RoomType with this id does not exist");
    }
}