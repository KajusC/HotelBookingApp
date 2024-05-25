using HotelBookingApp.Data.Models;

namespace HotelBookingApp.Data.Interfaces;

public interface IFoodRepository : IRepository<Food>
{
    Task<Food> GetFoodsWithDetailsAsync();
    Task<Food> GetFoodWithDetailsAsyncById(int id);
}