using System.Dynamic;
using HotelBookingApp.Data.Data;
using HotelBookingApp.Data.Interfaces;
using HotelBookingApp.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApp.Data.Repositories;

public class RoomTypeRepository : GeneralRepository<RoomType>, IRoomTypeRepository
{
    public RoomTypeRepository(HotelDataContext context) : base(context)
    {
    }
}