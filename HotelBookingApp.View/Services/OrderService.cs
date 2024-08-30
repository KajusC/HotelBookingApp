using AutoMapper;
using HotelBookingApp.Business.DTO;
using HotelBookingApp.Business.Interfaces;
using HotelBookingApp.Data.Interfaces;
using HotelBookingApp.Data.Entities;
using Microsoft.Extensions.Logging;

namespace HotelBookingApp.Business.Services;

public class OrderService : IOrderService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger<OrderDto> _logger;

    private readonly IOrderRepository _orderRepository;

    public OrderService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<OrderDto> logger)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _logger = logger;
        _orderRepository = unitOfWork.OrderRepository;
    }

    public async Task<IEnumerable<OrderDto>> GetAllAsync()
    {

        var entities = await _orderRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<OrderDto>>(entities);
    }

    public async Task<OrderDto> GetByIdAsync(int id)
    {
        var entity = await _orderRepository.GetByIdAsync(id);
        return _mapper.Map<OrderDto>(entity);
    }

    public async Task AddAsync(OrderDto model)
    {
        var entity = _mapper.Map<Order>(model);
        await _orderRepository.AddAsync(entity);
    }

    public async Task UpdateAsync(OrderDto model)
    {
        var entity = _mapper.Map<Order>(model);
        await _orderRepository.UpdateAsync(entity);
    }

    public async Task DeleteAsync(int modelId)
    {
        var entity = await _orderRepository.GetByIdAsync(modelId);
        await _orderRepository.DeleteAsync(entity);
    }

    public async Task<IEnumerable<OrderDto>> GetOrdersByCustomerId(int customerId)
    {
        var orders = await _orderRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<OrderDto>>(orders.Where(o => o.UserId == customerId));
    }
}
