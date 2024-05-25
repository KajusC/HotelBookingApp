using HotelBookingApp.Data.Data;
using HotelBookingApp.Data.Interfaces;
using HotelBookingApp.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApp.Data.Repositories;

public class OrderRepository : GeneralRepository<Order> , IOrderRepository
{
    public OrderRepository(HotelDataContext context) : base(context)
    {
    }

}