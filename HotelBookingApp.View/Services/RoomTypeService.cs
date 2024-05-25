using AutoMapper;
using HotelBookingApp.Business.DTO;
using HotelBookingApp.Business.Interfaces;
using HotelBookingApp.Data.Interfaces;
using HotelBookingApp.Data.Models;

namespace HotelBookingApp.Business.Services;

public class RoomTypeService : IRoomTypeService
{
    private readonly IUnitOfWork _unit;
    private readonly IRoomTypeRepository _roomTypeRepository;
    private readonly IMapper _mapper;

    public RoomTypeService(IUnitOfWork unit, IMapper mapper)
    {
        _unit = unit;
        _roomTypeRepository = unit.RoomTypeRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<RoomTypeModel>> GetAllAsync()
    {
        var roomTypes = await _roomTypeRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<RoomTypeModel>>(roomTypes);
    }

    public async Task<RoomTypeModel> GetByIdAsync(int id)
    {
        var roomType = await _roomTypeRepository.GetByIdAsync(id);
        return _mapper.Map<RoomTypeModel>(roomType);
    }

    public async Task AddAsync(RoomTypeModel model)
    {
        var roomType = _mapper.Map<RoomType>(model);
        await _roomTypeRepository.AddAsync(roomType);
    }

    public async Task UpdateAsync(RoomTypeModel model)
    {
        var currentRoomType = await _roomTypeRepository.GetByIdAsync(model.Id);

        _mapper.Map(model, currentRoomType);
        await _roomTypeRepository.UpdateAsync(currentRoomType);
    }

    public async Task DeleteAsync(int id)
    {
        await _roomTypeRepository.DeleteByIdAsync(id);
    }
}