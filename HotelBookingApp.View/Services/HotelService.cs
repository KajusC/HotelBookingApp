using AutoMapper;
using HotelBookingApp.Business.DTO;
using HotelBookingApp.Business.Interfaces;
using HotelBookingApp.Data.Entities;
using HotelBookingApp.Data.Interfaces;
using Microsoft.Extensions.Logging;

namespace HotelBookingApp.Business.Services;

public class HotelService : IHotelService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger<HotelDto> _logger;

    private readonly IHotelRepository _hotelRepository;

    public HotelService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<HotelDto> logger)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _logger = logger;
        _hotelRepository = unitOfWork.HotelRepository;
    }

    public async Task<IEnumerable<HotelDto>> GetAllAsync()
    {
        var entities = await _hotelRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<HotelDto>>(entities);
    }

    public async Task<HotelDto> GetByIdAsync(int id)
    {
        var entity = await _hotelRepository.GetByIdAsync(id);
        return _mapper.Map<HotelDto>(entity);
    }

    public async Task AddAsync(HotelDto model)
    {
        var entity = _mapper.Map<Hotel>(model);
        await _hotelRepository.AddAsync(entity);
    }

    public async Task UpdateAsync(HotelDto model)
    {
        var entity = _mapper.Map<Hotel>(model);
        await _hotelRepository.UpdateAsync(entity);
    }

    public async Task DeleteAsync(int modelId)
    {
        var entity = await _hotelRepository.GetByIdAsync(modelId);
        await _hotelRepository.DeleteAsync(entity);
    }

    public async Task<IEnumerable<HotelDto>> GetHotelByFoodInclusion(int foodInclusionId)
    {
        var hotels = await _hotelRepository.GetAllAsync();
        var filtered = hotels.Where(h => h.FoodHotels.Any(fh => fh.FoodId == foodInclusionId));
        return _mapper.Map<IEnumerable<HotelDto>>(filtered);
    }

    public async Task<IEnumerable<HotelDto>> GetHotelByRoomTypes(int roomTypeId)
    {
        var hotels = await _hotelRepository.GetAllAsync();
        var filtered = hotels.Where(h => h.RoomHotels.Any(rh => rh.Room.RoomTypeId == roomTypeId));
        return _mapper.Map<IEnumerable<HotelDto>>(filtered);
    }

    public async Task<IEnumerable<HotelDto>> GetHotelByCountryOrCity(string countryOrCity)
    {
        var hotels = await _hotelRepository.GetAllAsync();
        var filtered = hotels.Where(h => h.Country == countryOrCity || h.City == countryOrCity);
        return _mapper.Map<IEnumerable<HotelDto>>(filtered);
    }
}