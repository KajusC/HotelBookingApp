using AutoMapper;
using HotelBookingApp.Business.DTO;
using HotelBookingApp.Business.Interfaces;
using HotelBookingApp.Data.Interfaces;
using HotelBookingApp.Data.Entities;

namespace HotelBookingApp.Business.Services;

public class RoomService : GeneralService<RoomModel, Room>, IRoomService
{
    public RoomService(IRoomRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }
}
