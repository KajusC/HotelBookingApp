using AutoMapper;
using HotelBookingApp.Business.DTO;
using HotelBookingApp.Business.Interfaces;
using HotelBookingApp.Data.Interfaces;
using HotelBookingApp.Data.Entities;
using Microsoft.Extensions.Logging;

namespace HotelBookingApp.Business.Services;

public class OrderService : GeneralService<OrderModel, Order>, IOrderService
{
    public OrderService(IOrderRepository repository, IMapper mapper, ILogger<OrderModel> logger) : base(repository, mapper, logger)
    {
    }

    public async Task<IEnumerable<OrderModel>> GetOrdersByCustomerId(int customerId)
    {
        throw new NotImplementedException();
    }
}
