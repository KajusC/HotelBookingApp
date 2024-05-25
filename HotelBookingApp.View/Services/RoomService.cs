using AutoMapper;
using HotelBookingApp.Business.DTO;
using HotelBookingApp.Business.Interfaces;
using HotelBookingApp.Business.Validity;
using HotelBookingApp.Data.Data;
using HotelBookingApp.Data.Interfaces;
using HotelBookingApp.Data.Models;
using HotelBookingApp.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HotelBookingApp.Business.Services;

public class RoomService : IRoomService
{
    private readonly IUnitOfWork _unit;
    private readonly IRoomRepository _roomRepository;
    private readonly IRoomTypeRepository _roomTypeRepository;
    private readonly ILogger<RoomService> _log;
    private readonly IMapper _mapper;

    public RoomService(IUnitOfWork unit, IMapper mapper, ILogger<RoomService> logger)
    {
        _unit = unit;
        _roomRepository = unit.RoomRepository;
        _roomTypeRepository = unit.RoomTypeRepository;
        _log = logger;
        _mapper = mapper;
    }
    public async Task<IEnumerable<RoomModel>> GetAllAsync()
    {
        var rooms = await _roomRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<RoomModel>>(rooms);
    }

    public async Task<RoomModel> GetByIdAsync(int id)
    {
        var room = await _roomRepository.GetRoomWithDetailsAsyncById(id);
        return _mapper.Map<RoomModel>(room);
    }

    public async Task AddAsync(RoomModel model)
    {
        var roomType = await _roomTypeRepository.GetRoomTypeWithDetailsAsyncById(model.RoomTypeId);

        var room = _mapper.Map<Room>(model);
        if (roomType == null)
        {
            _log.LogWarning("No roomType was added");
            throw new ServiceException("RoomType not found");
        }

        room.RoomType = roomType;

        await _roomRepository.AddAsync(room);
        await _unit.SaveChangesAsync();
    }



    public async Task UpdateAsync(RoomModel model)
    {
        var currentRoom = await _roomRepository.GetByIdAsync(model.Id);

        _mapper.Map(model, currentRoom);
        await _roomRepository.UpdateAsync(currentRoom);
        await _unit.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await _roomRepository.DeleteByIdAsync(id);
        await _unit.SaveChangesAsync();
    }
}