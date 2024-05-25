using HotelBookingApp.Data.Data;
using HotelBookingApp.Data.Entities.ManyToMany;
using HotelBookingApp.Data.Interfaces.ManyToMany;

namespace HotelBookingApp.Data.Repositories;

public class RoomOrderRepository : GeneralRepository<RoomOrder>, IRoomOrderRepository
{
    public RoomOrderRepository(HotelDataContext context) : base(context)
    {
    }
}