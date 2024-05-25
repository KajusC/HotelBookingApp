using HotelBookingApp.Data.Models;

namespace HotelBookingApp.Data.Interfaces;

public interface IRoomRepository : IRepository<Room>
{
    Task<Room> GetRoomsWithDetailsAsync();
    Task<Room> GetRoomWithDetailsAsyncById(int id);
}