using HotelBookingApp.Business.DTO;

namespace HotelBookingApp.Business.Interfaces;

public interface IOrderService : ICrud<OrderDto>
{
    public Task<IEnumerable<OrderDto>> GetOrdersByCustomerId(int customerId);
}