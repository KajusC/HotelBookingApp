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

public class FoodService : GeneralService<FoodDto, Food>, IFoodService
{
    private readonly IFoodHotelRepository _foodHotelRepository;
    private readonly IFoodOrderRepository _foodOrderRepository;
    private readonly IHotelRepository _hotelRepository;
    private readonly IOrderRepository _orderRepository;
    public FoodService(IFoodRepository repository, IMapper mapper, IHotelRepository hotelRepository,
                        IFoodHotelRepository foodHotelRepository, IOrderRepository orderRepository,
                        IFoodOrderRepository foodOrderRepository, ILogger<FoodDto> logger) 
                        : base(repository, mapper, logger)
    {
        _hotelRepository = hotelRepository;
        _foodHotelRepository = foodHotelRepository;
        _orderRepository = orderRepository;
        _foodOrderRepository = foodOrderRepository;
    }

    public async Task JoinFoodWithHotel(int foodId, int hotelId)
    {
        var hotel = await _hotelRepository.GetByIdAsync(hotelId);
        if (hotel == null)
        {
            throw new ServiceException($"Hotel with Id {hotelId} does not exist.");
        }
        
        var food = await _repository.GetByIdAsync(foodId);
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


        hotel.FoodHotels.Add(foodHotel);
        await _hotelRepository.UpdateAsync(hotel);

        food.FoodHotels.Add(foodHotel);
        await _repository.UpdateAsync(food);

        await _foodHotelRepository.AddAsync(foodHotel);
    }

    public async Task JoinFoodWithOrder(int foodId, int orderId)
    {
        var food = await _repository.GetByIdAsync(foodId);
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
        await _repository.UpdateAsync(food);

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
