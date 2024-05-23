using HotelBookingApp.Data.Data;
using HotelBookingApp.Data.Interfaces;
using HotelBookingApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApp.Data.Repositories;

public class RoomRepository : IRoomRepository
{

    private readonly DbSet<Room> _rooms;
    private readonly HotelDataContext _hotelDataContext;
    public RoomRepository(HotelDataContext hotelDataContext)
    {
        _hotelDataContext = hotelDataContext;
        _rooms = hotelDataContext.Rooms;
    }
    public async Task<IEnumerable<Room>> GetAllAsync()
    {
        return await _rooms.ToListAsync();
    }

    public async Task<Room> GetByIdAsync(int id)
    {
        return await _rooms.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<bool> AddAsync(Room entity)
    {
        await _rooms.AddAsync(entity);
        return await _hotelDataContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> UpdateAsync(Room entity)
    {
        _rooms.Update(entity);
        return await _hotelDataContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var room = await GetByIdAsync(id);
        _rooms.Remove(room);
        return await _hotelDataContext.SaveChangesAsync() > 0;
    }
}