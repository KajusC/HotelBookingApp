using HotelBookingApp.Data.Models;

namespace HotelBookingApp.Data.Interfaces;

public interface IHotelRepository : IRepository<Hotel>
{
    Task<Hotel> GetHotelsWithDetailsAsync();
    Task<Hotel> GetHotelWithDetailsAsyncById(int id);
}