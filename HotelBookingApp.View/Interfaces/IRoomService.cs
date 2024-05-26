using HotelBookingApp.Business.DTO;

namespace HotelBookingApp.Business.Interfaces;

public interface IRoomService : ICrud<RoomModel>
{
    Task JoinRoomWithOrder(int roomId, int orderId);
}