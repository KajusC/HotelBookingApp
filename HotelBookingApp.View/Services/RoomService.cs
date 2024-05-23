using AutoMapper;
using HotelBookingApp.Business.DTO;
using HotelBookingApp.Business.Interfaces;
using HotelBookingApp.Data.Interfaces;

namespace HotelBookingApp.Business.Services;

public class RoomService : IRoomService
{
    private readonly IUnitOfWork _unit;
    private readonly IRoomRepository _roomRepository;
    private readonly IMapper _mapper;

    public RoomService(IUnitOfWork unit, IMapper mapper)
    {
        _unit = unit;
        _roomRepository = unit.RoomRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<RoomModel>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<RoomModel> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> AddAsync(RoomModel model)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> UpdateAsync(int id, RoomModel model)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}