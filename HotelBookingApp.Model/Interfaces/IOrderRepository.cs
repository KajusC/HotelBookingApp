using HotelBookingApp.Data.Models;

namespace HotelBookingApp.Data.Interfaces;

public interface IOrderRepository : IRepository<Order>
{
    Task<Order> GetOrdersWithDetailsAsync();
    Task<Order> GetOrderWithDetailsAsyncById(int id);
}