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
        var hotels = await _dbSet
            .Include(h => h.HotelRooms)
            .ThenInclude(r => r.Room)
            .Include(h => h.HotelRooms)
            .Include(h => h.HotelFoods)
            .Include(h => h.Orders)
            .ToListAsync();

        foreach (var hotel in hotels)
        {
            hotel.Name = hotel.Name.ToLower();
            hotel.Address = hotel.Address.ToLower();
            hotel.City = hotel.City.ToLower();
            hotel.Country = hotel.Country.ToLower();
        }
        return hotels;
    }

    public override async Task<Hotel> GetByIdAsync(int id)
    {
        return await _dbSet
            .Include(h => h.HotelRooms)
            .ThenInclude(r => r.Room)
            .Include(h => h.HotelRooms)
            .Include(h => h.HotelFoods)
            .Include(h => h.Orders)
            .FirstOrDefaultAsync(h => h.Id == id) ?? throw new ArgumentException("Hotel with this id does not exist");
    }

    public async Task<Hotel> GetHotelByUserId(int id)
    {
        return await _dbSet
            .Include(h => h.HotelRooms)
            .ThenInclude(r => r.Room)
            .Include(h => h.HotelRooms)
            .Include(h => h.HotelFoods)
            .Include(h => h.Orders)
            .FirstOrDefaultAsync(h => h.UserId == id) ?? throw new ArgumentException("Hotel with this user id does not exist");
    }
}