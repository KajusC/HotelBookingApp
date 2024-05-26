using HotelBookingApp.Data.Data;
using HotelBookingApp.Data.Entities.ManyToMany;
using HotelBookingApp.Data.Interfaces.ManyToMany;

namespace HotelBookingApp.Data.Repositories;

public class RoomHotelRepository : GeneralRepository<RoomHotel>, IRoomHotelRepository
{
    public RoomHotelRepository(HotelDataContext context) : base(context)
    {
    }
}