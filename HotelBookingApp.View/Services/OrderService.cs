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

    public async Task<IEnumerable<OrderModel>> GetOrdersByCustomerId(int customerId)
    {
        var orders = await _orderRepository.GetAllAsync();
        var selectedOrders = orders.Where(x => x.CustomerId == customerId);
        return _mapper.Map<IEnumerable<OrderModel>>(selectedOrders);
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

    public async Task AddAsync(OrderModel model)
    {
        var order = _mapper.Map<Order>(model);
        await _orderRepository.AddAsync(order);
        await _unit.SaveChangesAsync();
    }

    public async Task UpdateAsync(OrderModel model)
    {
        var currentOrder = await _orderRepository.GetByIdAsync(model.Id);
        if (currentOrder == null)
        {
            return;
        }

        _mapper.Map(model, currentOrder);
        await _orderRepository.UpdateAsync(currentOrder);
        await _unit.SaveChangesAsync();
    }

    public async Task DeleteAsync(int modelId)
    {
        await _orderRepository.DeleteByIdAsync(modelId);
        await _unit.SaveChangesAsync();
    }
}