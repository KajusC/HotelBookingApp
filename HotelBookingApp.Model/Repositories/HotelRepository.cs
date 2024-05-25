using HotelBookingApp.Data.Data;
using HotelBookingApp.Data.Interfaces;
using HotelBookingApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApp.Data.Repositories;

public class HotelRepository : IHotelRepository
{
    private readonly DbSet<Hotel> _hotels;
    private readonly HotelDataContext _hotelDataContext;

    public HotelRepository(HotelDataContext hotelDataContext)
    {
        _hotelDataContext = hotelDataContext;
        _hotels = hotelDataContext.Hotels;
    }

    public async Task<IEnumerable<Hotel>> GetAllAsync()
    {
        return await _hotels
            .Include(h => h.Rooms)
            .Include(h => h.Foods)
            .ToListAsync();
    }

    public async Task<Hotel> GetByIdAsync(int id)
    {
        return await _hotels
            .Include(h => h.Rooms)
            .Include(h => h.Foods)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task AddAsync(Hotel entity)
    {
        await _hotels.AddAsync(entity);
        await _hotelDataContext.SaveChangesAsync();
    }

    public async Task Delete(Hotel entity)
    {
        _hotels.Remove(entity);
        await _hotelDataContext.SaveChangesAsync();
    }

    public async Task DeleteByIdAsync(int id)
    {
        var hotel = await GetByIdAsync(id);
        if (hotel == null) return;

        _hotels.Remove(hotel);
        await _hotelDataContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Hotel entity)
    {
        _hotels.Update(entity);
        await _hotelDataContext.SaveChangesAsync();
    }

    public async Task<Hotel> GetHotelsWithDetailsAsync()
    {
        return await _hotels
            .Include(h => h.Rooms)
            .Include(h => h.Foods)
            .FirstOrDefaultAsync();
    }

    public async Task<Hotel> GetHotelWithDetailsAsyncById(int id)
    {
        return await _hotels
            .Include(h => h.Rooms)
            .Include(h => h.Foods)
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}
