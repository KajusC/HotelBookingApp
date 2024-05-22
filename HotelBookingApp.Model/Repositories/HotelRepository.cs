using HotelBookingApp.Model.Data;
using HotelBookingApp.Model.Interfaces;
using HotelBookingApp.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApp.Model.Repositories;

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
        return await _hotels.ToListAsync();
    }

    public async Task<Hotel> GetByIdAsync(int id)
    {
        return await _hotels.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<bool> AddAsync(Hotel entity)
    {
        await _hotels.AddAsync(entity);
        return await _hotelDataContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> UpdateAsync(Hotel entity)
    {
        _hotels.Update(entity);
        return await _hotelDataContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var hotel = await GetByIdAsync(id);
        _hotels.Remove(hotel);
        return await _hotelDataContext.SaveChangesAsync() > 0;
    }
}