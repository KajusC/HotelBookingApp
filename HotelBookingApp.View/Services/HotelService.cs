using AutoMapper;
using HotelBookingApp.Business.DTO;
using HotelBookingApp.Business.Interfaces;
using HotelBookingApp.Data.Interfaces;
using HotelBookingApp.Data.Models;

namespace HotelBookingApp.Business.Services;

public class HotelService : IHotelService
{
    private readonly IUnitOfWork _unit;
    private readonly IHotelRepository _hotelRepository;
    private readonly IMapper _mapper;

    public HotelService(IUnitOfWork unit, IMapper mapper)
    {
        _unit = unit;
        _hotelRepository = unit.HotelRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<HotelModel>> GetAllAsync()
    {
        var hotels = await _hotelRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<HotelModel>>(hotels);
    }

    public async Task<HotelModel> GetByIdAsync(int id)
    {
        var hotel = await _hotelRepository.GetByIdAsync(id);
        return _mapper.Map<HotelModel>(hotel);
    }

    public async Task AddAsync(HotelModel model)
    {
        var hotel = _mapper.Map<Hotel>(model);
        await _hotelRepository.AddAsync(hotel);
        await _unit.SaveChangesAsync();
    }

    public async Task UpdateAsync(HotelModel model)
    {
        var currentHotel = await _hotelRepository.GetByIdAsync(model.Id);
        if (currentHotel == null)
        {
            return;
        }

        _mapper.Map(model, currentHotel);
        await _hotelRepository.UpdateAsync(currentHotel);
        await _unit.SaveChangesAsync();
    }

    public async Task DeleteAsync(int modelId)
    {
        await _hotelRepository.DeleteByIdAsync(modelId);
        await _unit.SaveChangesAsync();
    }

    public async Task<IEnumerable<HotelModel>> GetHotelByFoodInclusion(int foodInclusionId)
    {
        var hotels = await _hotelRepository.GetAllAsync();
        var selectedHotels = hotels.Where(x => x.Foods.Any(food => food.Id == foodInclusionId));
        return _mapper.Map<IEnumerable<HotelModel>>(selectedHotels);
    }

    public async Task<IEnumerable<HotelModel>> GetHotelByRoomTypes(int roomTypeId)
    {
        var hotels = await _hotelRepository.GetAllAsync();
        var selectedHotels = hotels.Where(x => x.Rooms.Any(room => room.RoomTypeId == roomTypeId));
        return _mapper.Map<IEnumerable<HotelModel>>(selectedHotels);
    }
}