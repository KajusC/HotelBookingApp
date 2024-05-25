using AutoMapper;
using HotelBookingApp.Business.DTO;
using HotelBookingApp.Business.Interfaces;
using HotelBookingApp.Data.Interfaces;
using HotelBookingApp.Data.Entities;

namespace HotelBookingApp.Business.Services;

public class FoodService : GeneralService<FoodModel, Food>, IFoodService
{
    public FoodService(IFoodRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }
}
