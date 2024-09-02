using HotelBookingApp.Data.Entities;

namespace HotelBookingApp.Data.Interfaces;

public interface IHotelRepository : IRepository<Hotel>
{
    Task<Hotel> GetHotelByUserId(int id);
}