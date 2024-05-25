using HotelBookingApp.Data.Data;
using HotelBookingApp.Data.Interfaces;
using HotelBookingApp.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApp.Data.Repositories;

public class HotelRepository : GeneralRepository<Hotel>, IHotelRepository
{
    public HotelRepository(HotelDataContext context) : base(context)
    {
    }
}