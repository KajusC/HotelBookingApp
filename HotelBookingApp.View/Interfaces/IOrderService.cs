using HotelBookingApp.Business.DTO;

namespace HotelBookingApp.Business.Interfaces;

public interface IOrderService : ICrud<OrderModel>
{
    public Task<IEnumerable<OrderModel>> GetOrdersByCustomerId(int customerId);
}