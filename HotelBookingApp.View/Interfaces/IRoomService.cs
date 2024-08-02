using HotelBookingApp.Business.DTO;

namespace HotelBookingApp.Business.Interfaces;

public interface IRoomService : ICrud<RoomDto>
{
    Task JoinRoomWithOrder(int roomId, int orderId);
    Task<IEnumerable<RoomDto>> GetRoomsByHotelId(int hotelId);
    Task JoinRoomsWithHotel(int roomId, int hotelId);
}