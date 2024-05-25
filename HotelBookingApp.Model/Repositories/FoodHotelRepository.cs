using HotelBookingApp.Data.Data;
using HotelBookingApp.Data.Entities.ManyToMany;
using HotelBookingApp.Data.Interfaces.ManyToMany;

namespace HotelBookingApp.Data.Repositories;

public class FoodHotelRepository : GeneralRepository<FoodHotel>, IFoodHotelRepository
{
    public FoodHotelRepository(HotelDataContext context) : base(context)
    {
    }
}
