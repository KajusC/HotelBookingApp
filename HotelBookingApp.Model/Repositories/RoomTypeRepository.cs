using HotelBookingApp.Model.Data;
using HotelBookingApp.Model.Interfaces;
using HotelBookingApp.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApp.Model.Repositories;

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

    public async Task<bool> AddAsync(RoomType entity)
    {
        await _roomTypes.AddAsync(entity);
        return await _hotelDataContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> UpdateAsync(RoomType entity)
    {
        _roomTypes.Update(entity);
        return await _hotelDataContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var roomType = await GetByIdAsync(id);
        _roomTypes.Remove(roomType);
        return await _hotelDataContext.SaveChangesAsync() > 0;
    }
}