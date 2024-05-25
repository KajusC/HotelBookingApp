using HotelBookingApp.Data.Data;
using HotelBookingApp.Data.Interfaces;
using HotelBookingApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApp.Data.Repositories;

public class RoomTypeRepository : IRoomTypeRepository
{

    private readonly DbSet<RoomType> _roomTypes;
    private readonly HotelDataContext _hotelDataContext;
    public RoomTypeRepository(HotelDataContext hotelDataContext)
    {
        _hotelDataContext = hotelDataContext;
        _roomTypes = hotelDataContext.RoomTypes;
    }

    public async Task<IEnumerable<RoomType>> GetAllAsync()
    {
        return await _roomTypes.ToListAsync();
    }

    public async Task<RoomType> GetByIdAsync(int id)
    {
        return await _roomTypes.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task AddAsync(RoomType entity)
    {
        await _roomTypes.AddAsync(entity);
        await _hotelDataContext.SaveChangesAsync();
    }

    public async Task Delete(RoomType entity)
    {
        _roomTypes.Remove(entity);
        await _hotelDataContext.SaveChangesAsync();
    }

    public async Task DeleteByIdAsync(int id)
    {
        var roomType = await GetByIdAsync(id);
        if (roomType == null) return;

        _roomTypes.Remove(roomType);
        await _hotelDataContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(RoomType entity)
    {
        _roomTypes.Update(entity);
        await _hotelDataContext.SaveChangesAsync();
    }

    public async Task<RoomType> GetRoomTypesWithDetailsAsync()
    {
        return await _roomTypes
            .Include(rt => rt.Rooms)
            .FirstOrDefaultAsync();
    }

    public async Task<RoomType> GetRoomTypeWithDetailsAsyncById(int id)
    {
        return await _roomTypes
            .Include(rt => rt.Rooms)
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}