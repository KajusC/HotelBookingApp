using AutoMapper;
using HotelBookingApp.Business.DTO;
using HotelBookingApp.Business.Interfaces;
using HotelBookingApp.Data.Entities;
using HotelBookingApp.Data.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.Extensions.Logging;

namespace HotelBookingApp.Business.Services;

public class HotelService : IHotelService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger<HotelDto> _logger;

    private readonly IHotelRepository _hotelRepository;
    private readonly IUserRepository _userRepository;

    public HotelService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<HotelDto> logger)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _logger = logger;
        _hotelRepository = unitOfWork.HotelRepository;
        _userRepository = unitOfWork.UserRepository;
    }

    public async Task<IEnumerable<HotelDto>> GetAllAsync()
    {
        var entities = await _hotelRepository.GetAllAsync();
        var mapped = _mapper.Map<IEnumerable<HotelDto>>(entities);

        foreach (var hotel in mapped)
        {
            hotel.MinBedCount = await GetMinBedCount(hotel.Id);
            hotel.MaxBedCount = await GetMaxBedCount(hotel.Id);
            hotel.minGuestCount = await GetMinGuestCount(hotel.Id);
            hotel.maxGuestCount = await GetMaxGuestCount(hotel.Id);
            hotel.AveragePrice = await GetAveragePrice(hotel.Id);
        }

        return mapped;
    }

    public async Task<HotelDto> GetByIdAsync(int id)
    {
        var entity = await _hotelRepository.GetByIdAsync(id);
        var mapped = _mapper.Map<HotelDto>(entity);

        mapped.MinBedCount = await GetMinBedCount(mapped.Id);
        mapped.MaxBedCount = await GetMaxBedCount(mapped.Id);
        mapped.minGuestCount = await GetMinGuestCount(mapped.Id);
        mapped.maxGuestCount = await GetMaxGuestCount(mapped.Id);
        mapped.AveragePrice = await GetAveragePrice(mapped.Id);
        return mapped;
    }

    public async Task AddAsync(HotelDto model)
    {
        var entity = _mapper.Map<Hotel>(model);

        if (entity.UserId != null)
        {
            int userId = (int)entity.UserId;

            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
            {
                throw new ArgumentException("User with this id does not exist");
            }
            
            user.HotelId = entity.Id;
            user.Hotel = entity;
            await _userRepository.UpdateAsync(user);
        }

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
        var filtered = hotels.Where(h => h.HotelFoods.Any(fh => fh.FoodId == foodInclusionId));
        var mapped = _mapper.Map<IEnumerable<HotelDto>>(filtered);

        foreach (var hotel in mapped)
        {
            hotel.MinBedCount = await GetMinBedCount(hotel.Id);
            hotel.MaxBedCount = await GetMaxBedCount(hotel.Id);
            hotel.minGuestCount = await GetMinGuestCount(hotel.Id);
            hotel.maxGuestCount = await GetMaxGuestCount(hotel.Id);
            hotel.AveragePrice = await GetAveragePrice(hotel.Id);
        }

        return mapped;
    }

    public async Task<IEnumerable<HotelDto>> GetHotelByRoomTypes(int roomTypeId)
    {
        var hotels = await _hotelRepository.GetAllAsync();
        var filtered = hotels.Where(h => h.HotelRooms.Any(rh => rh.Room.RoomTypeId == roomTypeId));
        var mapped = _mapper.Map<IEnumerable<HotelDto>>(filtered);

        foreach (var hotel in mapped)
        {
            hotel.MinBedCount = await GetMinBedCount(hotel.Id);
            hotel.MaxBedCount = await GetMaxBedCount(hotel.Id);
            hotel.minGuestCount = await GetMinGuestCount(hotel.Id);
            hotel.maxGuestCount = await GetMaxGuestCount(hotel.Id);
            hotel.AveragePrice = await GetAveragePrice(hotel.Id);
        }

        return mapped;
    }

    public async Task<IEnumerable<HotelDto>> GetHotelByCountryOrCity(string countryOrCity)
    {
        var hotels = await _hotelRepository.GetAllAsync();
        var filtered = hotels.Where(h => h.Country.ToLower() == countryOrCity || h.City.ToLower() == countryOrCity);
        var mapped = _mapper.Map<IEnumerable<HotelDto>>(filtered);

        foreach (var hotel in mapped)
        {
            hotel.MinBedCount = await GetMinBedCount(hotel.Id);
            hotel.MaxBedCount = await GetMaxBedCount(hotel.Id);
            hotel.minGuestCount = await GetMinGuestCount(hotel.Id);
            hotel.maxGuestCount = await GetMaxGuestCount(hotel.Id);
            hotel.AveragePrice = await GetAveragePrice(hotel.Id);
        }

        return mapped;
    }

    public async Task<HotelDto> GetHotelByUserId(int userId)
    {
        var entity = await _hotelRepository.GetHotelByUserId(userId);
        var mapped = _mapper.Map<HotelDto>(entity);

        mapped.MinBedCount = await GetMinBedCount(mapped.Id);
        mapped.MaxBedCount = await GetMaxBedCount(mapped.Id);
        mapped.minGuestCount = await GetMinGuestCount(mapped.Id);
        mapped.maxGuestCount = await GetMaxGuestCount(mapped.Id);
        mapped.AveragePrice = await GetAveragePrice(mapped.Id);
        return mapped;
    }

    private async Task<int> GetMinGuestCount(int hotelId)
    {
        var hotel = await _hotelRepository.GetByIdAsync(hotelId);
        if (hotel.HotelRooms == null || hotel.HotelRooms.Count == 0)
        {
            return 0;
        }

        return hotel.HotelRooms.Min(rh => rh.Room.Capacity);
    }

    private async Task<int> GetMaxGuestCount(int hotelId)
    {
        var hotel = await _hotelRepository.GetByIdAsync(hotelId);
        if (hotel.HotelRooms == null || hotel.HotelRooms.Count == 0)
        {
            return 0;
        }

        return hotel.HotelRooms.Max(rh => rh.Room.Capacity);
    }

    private async Task<int> GetMinBedCount(int hotelId)
    {
        var hotel = await _hotelRepository.GetByIdAsync(hotelId);
        if (hotel.HotelRooms == null || hotel.HotelRooms.Count == 0)
        {
            return 0;
        }

        return hotel.HotelRooms.Min(rh => rh.Room.BedCount);
    }

    private async Task<int> GetMaxBedCount(int hotelId)
    {
        var hotel = await _hotelRepository.GetByIdAsync(hotelId);
        if (hotel.HotelRooms == null || hotel.HotelRooms.Count == 0)
        {
            return 0;
        }

        return hotel.HotelRooms.Max(rh => rh.Room.BedCount);
    }

    public async Task<double> GetAveragePrice(int hotelId)
    {
        var hotel = await _hotelRepository.GetByIdAsync(hotelId);
        if (hotel.HotelRooms == null || hotel.HotelRooms.Count == 0)
        {
            return 0;
        }

        return hotel.HotelRooms.Average(rh => rh.Room.Price);
    }
}