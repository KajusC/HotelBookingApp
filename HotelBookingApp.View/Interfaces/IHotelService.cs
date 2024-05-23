using HotelBookingApp.Business.DTO;

namespace HotelBookingApp.Business.Interfaces;

public interface IHotelService : ICrud<HotelModel>
{
    public Task<IEnumerable<HotelModel>> GetHotelByFoodInclusion(int foodInclusionId); //Breakfast, Lunch, Dinner etc.
    public Task<IEnumerable<HotelModel>> GetHotelByRoomTypes(int roomTypeId); //Single, Double, Triple etc.
}