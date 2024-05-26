using AutoMapper;
using HotelBookingApp.Business.DTO;
using HotelBookingApp.Business.Interfaces;
using HotelBookingApp.Data.Interfaces;
using HotelBookingApp.Data.Entities;
using Microsoft.Extensions.Logging;

namespace HotelBookingApp.Business.Services;

public class RoomService : GeneralService<RoomModel, Room>, IRoomService
{
    public RoomService(IRoomRepository repository, IMapper mapper, ILogger<RoomModel> logger) : base(repository, mapper, logger)
    {
    }

    public async Task JoinRoomWithOrder(int roomId, int orderId)
    {
        throw new NotImplementedException();
    }
}
