using AutoMapper;
using HotelBookingApp.Business.DTO;
using HotelBookingApp.Business.DTO.ManyToMany;
using HotelBookingApp.Business.Interfaces;
using HotelBookingApp.Business.Validity;
using HotelBookingApp.Data.Interfaces;
using HotelBookingApp.Data.Entities;
using HotelBookingApp.Data.Entities.ManyToMany;
using HotelBookingApp.Data.Interfaces.ManyToMany;
using Microsoft.Extensions.Logging;

namespace HotelBookingApp.Business.Services;

public class FoodService : IFoodService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger<FoodDto> _logger;

    private readonly IFoodRepository _foodRepository;
    private readonly IHotelRepository _hotelRepository;
    private readonly IOrderRepository _orderRepository;
    private readonly IFoodHotelRepository _foodHotelRepository;
    private readonly IFoodOrderRepository _foodOrderRepository;

    public FoodService(IMapper mapper, ILogger<FoodDto> logger, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _logger = logger;

        _foodRepository = unitOfWork.FoodRepository;
        _hotelRepository = unitOfWork.HotelRepository;
        _orderRepository = unitOfWork.OrderRepository;
        _foodHotelRepository = unitOfWork.FoodHotelRepository;
        _foodOrderRepository = unitOfWork.FoodOrderRepository;
    }

    public async Task<IEnumerable<FoodDto>> GetAllAsync()
    {
        var entities = await _foodRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<FoodDto>>(entities);
    }

    public async Task<FoodDto> GetByIdAsync(int id)
    {
        var entity = await _foodRepository.GetByIdAsync(id);
        return _mapper.Map<FoodDto>(entity);
    }

    public async Task AddAsync(FoodDto model)
    {
        var entity = _mapper.Map<Food>(model);
        await _foodRepository.AddAsync(entity);
    }

    public async Task UpdateAsync(FoodDto model)
    {
        var entity = _mapper.Map<Food>(model);
        await _foodRepository.UpdateAsync(entity);
    }

    public async Task DeleteAsync(int modelId)
    {
        var entity = await _foodRepository.GetByIdAsync(modelId);
        await _foodRepository.DeleteAsync(entity);
    }

    public async Task JoinFoodWithHotel(int foodId, int hotelId)
    {
        var hotel = await _hotelRepository.GetByIdAsync(hotelId);
        if (hotel == null)
        {
            throw new ServiceException($"Hotel with Id {hotelId} does not exist.");
        }
        
        var food = await _foodRepository.GetByIdAsync(foodId);
        if (food == null)
        {
            throw new ServiceException($"Food with Id {foodId} does not exist.");
        }

        var foodHotel = new FoodHotel
        {
            FoodId = foodId,
            Food = food,
            HotelId = hotelId,
            Hotel = hotel,
        };

        hotel.HotelFoods.Add(foodHotel);
        await _hotelRepository.UpdateAsync(hotel);

        food.FoodHotels.Add(foodHotel);
        await _foodRepository.UpdateAsync(food);

        await _foodHotelRepository.AddAsync(foodHotel);
    }

    public async Task JoinFoodWithOrder(int foodId, int orderId)
    {
        var food = await _foodRepository.GetByIdAsync(foodId);
        if (food == null)
        {
            throw new ServiceException($"Food with Id {foodId} does not exist.");
        }

        foreach (var vFoodOrder in food.FoodOrders)
        {
            _logger.LogInformation("Is present: "+ vFoodOrder.Id.ToString());
        }

        var order = await _orderRepository.GetByIdAsync(orderId);
        if (order == null)
        {
            throw new ServiceException($"Order with Id {orderId} does not exist.");
        }

        var foodOrder = new FoodOrder
        {
            FoodId = foodId,
            Food = food,
            OrderId = orderId,
            Order = order,
        };

        food.FoodOrders.Add(foodOrder);
        await _foodRepository.UpdateAsync(food);

        order.FoodOrders.Add(foodOrder);
        await _orderRepository.UpdateAsync(order);

        await _foodOrderRepository.AddAsync(foodOrder);
    }

    public async Task<IEnumerable<HotelFoodDto>> GetAllFoodHotelLinks()
    {
        var models = await _foodHotelRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<HotelFoodDto>>(models);
    }
}
