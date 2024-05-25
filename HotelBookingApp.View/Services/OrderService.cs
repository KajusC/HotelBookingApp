using AutoMapper;
using HotelBookingApp.Business.DTO;
using HotelBookingApp.Business.Interfaces;
using HotelBookingApp.Data.Interfaces;
using HotelBookingApp.Data.Entities;

namespace HotelBookingApp.Business.Services;

public class OrderService : GeneralService<OrderModel, Order>, IOrderService
{
    public OrderService(IOrderRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }

    public async Task<IEnumerable<OrderModel>> GetOrdersByCustomerId(int customerId)
    {
        throw new NotImplementedException();
    }
}
