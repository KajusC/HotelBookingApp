using HotelBookingApp.Data.Data;
using HotelBookingApp.Data.Interfaces;
using HotelBookingApp.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApp.Data.Repositories;

public class FoodRepository : GeneralRepository<Food>, IFoodRepository
{
    public FoodRepository(HotelDataContext context) : base(context)
    {
    }
}