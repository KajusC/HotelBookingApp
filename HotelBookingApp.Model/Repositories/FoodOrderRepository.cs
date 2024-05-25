using HotelBookingApp.Data.Data;
using HotelBookingApp.Data.Entities.ManyToMany;
using HotelBookingApp.Data.Interfaces.ManyToMany;

namespace HotelBookingApp.Data.Repositories;

public class FoodOrderRepository : GeneralRepository<FoodOrder>, IFoodOrderRepository
{
    public FoodOrderRepository(HotelDataContext context) : base(context)
    {
    }
}
