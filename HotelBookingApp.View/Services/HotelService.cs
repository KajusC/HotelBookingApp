using AutoMapper;
using HotelBookingApp.Business.DTO;
using HotelBookingApp.Business.Interfaces;
using HotelBookingApp.Data.Interfaces;
using HotelBookingApp.Data.Entities;
using Microsoft.Extensions.Logging;

namespace HotelBookingApp.Business.Services;

public class HotelService : GeneralService<HotelDto, Hotel>, IHotelService
{
    public HotelService(IHotelRepository repository, IMapper mapper, ILogger<HotelDto> logger) : base(repository, mapper, logger)
    {
    }

    public async Task<IEnumerable<HotelDto>> GetHotelByFoodInclusion(int foodInclusionId)
    {
        var hotels = await _repository.GetAllAsync();
        var filtered = hotels.Where(h => h.FoodHotels.Any(fh => fh.FoodId == foodInclusionId));
        return _mapper.Map<IEnumerable<HotelDto>>(filtered);

    }

    public async Task<IEnumerable<HotelDto>> GetHotelByRoomTypes(int roomTypeId)
    {
        var hotels = await _repository.GetAllAsync();
        var filtered = hotels.Where(h => h.RoomHotels.Any(rh => rh.Room.RoomTypeId == roomTypeId));
        return _mapper.Map<IEnumerable<HotelDto>>(filtered);
    }

    public async Task<IEnumerable<HotelDto>> GetHotelByCountryOrCity(string countryOrCity)
    {
        var hotels = await _repository.GetAllAsync();
        var filtered = hotels.Where(h => h.Country == countryOrCity || h.City == countryOrCity);
        return _mapper.Map<IEnumerable<HotelDto>>(filtered);
    }
}