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

    public async Task AddAsync(Room entity)
    {
        await _rooms.AddAsync(entity);
        await _hotelDataContext.SaveChangesAsync();
    }

    public async Task Delete(Room entity)
    {
        _rooms.Remove(entity);
        await _hotelDataContext.SaveChangesAsync();
    }

    public async Task DeleteByIdAsync(int id)
    {
        var room = await GetByIdAsync(id);
        if (room == null) return;

        _rooms.Remove(room);
        await _hotelDataContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Room entity)
    {
        _rooms.Update(entity);
        await _hotelDataContext.SaveChangesAsync();
    }

    public async Task<Room> GetRoomsWithDetailsAsync()
    {
        return await _rooms
            .Include(r => r.Hotels)
            .Include(r => r.Orders)
            .FirstOrDefaultAsync();
    }

    public async Task<Room> GetRoomWithDetailsAsyncById(int id)
    {
        return await _rooms
            .Include(r => r.Hotels)
            .Include(r => r.Orders)
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}
