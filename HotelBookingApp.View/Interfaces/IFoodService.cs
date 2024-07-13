using HotelBookingApp.Business.DTO;
using HotelBookingApp.Business.DTO.ManyToMany;
using HotelBookingApp.Data.Entities.ManyToMany;

namespace HotelBookingApp.Business.Interfaces;

public interface IFoodService : ICrud<FoodDto>
{
    Task JoinFoodWithHotel(int foodId, int hotelId);
    Task JoinFoodWithOrder(int foodId, int orderId);

    Task<IEnumerable<HotelFoodDto>> GetAllFoodHotelLinks();
}