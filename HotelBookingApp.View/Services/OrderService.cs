using AutoMapper;
using HotelBookingApp.Business.DTO;
using HotelBookingApp.Business.Interfaces;
using HotelBookingApp.Data.Interfaces;
using HotelBookingApp.Data.Models;

namespace HotelBookingApp.Business.Services;

public class OrderService : IOrderService
{
    private readonly IUnitOfWork _unit;
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public OrderService(IUnitOfWork unit, IMapper mapper)
    {
        _unit = unit;
        _orderRepository = unit.OrderRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<OrderModel>> GetAllAsync()
    {
        var orders = await _orderRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<OrderModel>>(orders);
    }

    public async Task<OrderModel> GetByIdAsync(int id)
    {
        var order = await _orderRepository.GetByIdAsync(id);
        return _mapper.Map<OrderModel>(order);
    }

    public async Task<bool> AddAsync(OrderModel model)
    {
        var order = _mapper.Map<Order>(model);
        return await _orderRepository.AddAsync(order);
    }

    public async Task<bool> UpdateAsync(OrderModel model)
    {
        var currentOrder = await _orderRepository.GetByIdAsync(model.Id);
        if (currentOrder == null)
        {
            return false;
        }

        _mapper.Map(model, currentOrder);
        return await _orderRepository.UpdateAsync(currentOrder);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _orderRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<OrderModel>> GetOrdersByCustomerId(int customerId)
    {
        var orders = await _orderRepository.GetAllAsync();
        var selectedOrders = orders.Where(x => x.CustomerId == customerId);
        return _mapper.Map<IEnumerable<OrderModel>>(selectedOrders);
    }
}