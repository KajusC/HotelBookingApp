using HotelBookingApp.Business.DTO;

namespace HotelBookingApp.Business.Interfaces;

public interface IHotelService : ICrud<HotelDto>
{
    public Task<IEnumerable<HotelDto>> GetHotelByFoodInclusion(int foodInclusionId); //Breakfast, Lunch, Dinner etc.
    public Task<IEnumerable<HotelDto>> GetHotelByRoomTypes(int roomTypeId); //Single, Double, Triple etc.
    public Task<IEnumerable<HotelDto>> GetHotelByCountryOrCity(string countryOrCity);
    public Task<HotelDto> GetHotelByUserId(int userId);
}