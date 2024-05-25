using HotelBookingApp.Data.Models;

namespace HotelBookingApp.Data.Interfaces;

public interface IRoomTypeRepository : IRepository<RoomType>
{
    Task<RoomType> GetRoomTypesWithDetailsAsync();
    Task<RoomType> GetRoomTypeWithDetailsAsyncById(int id);
}