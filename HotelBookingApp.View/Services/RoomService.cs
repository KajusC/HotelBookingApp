using AutoMapper;
using HotelBookingApp.Business.DTO;
using HotelBookingApp.Business.Interfaces;
using HotelBookingApp.Data.Interfaces;
using HotelBookingApp.Data.Models;

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
        var rooms = await _roomRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<RoomModel>>(rooms);
    }

    public async Task<RoomModel> GetByIdAsync(int id)
    {
        var room = await _roomRepository.GetByIdAsync(id);
        return _mapper.Map<RoomModel>(room);
    }

    public async Task<bool> AddAsync(RoomModel model)
    {
        var room = _mapper.Map<Room>(model);
        return await _roomRepository.AddAsync(room);
    }

    public async Task<bool> UpdateAsync(RoomModel model)
    {
        var currentRoom = await _roomRepository.GetByIdAsync(model.Id);
        if (currentRoom == null)
        {
            return false;
        }

        _mapper.Map(model, currentRoom);
        return await _roomRepository.UpdateAsync(currentRoom);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _roomRepository.DeleteAsync(id);
    }
}