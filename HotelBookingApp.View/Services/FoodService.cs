using AutoMapper;
using HotelBookingApp.Business.DTO;
using HotelBookingApp.Business.Interfaces;
using HotelBookingApp.Data.Interfaces;
using HotelBookingApp.Data.Models;

namespace HotelBookingApp.Business.Services;

public class FoodService : IFoodService
{
    private readonly IUnitOfWork _unit;
    private readonly IFoodRepository _foodRepository;
    private readonly IMapper _mapper;

    public FoodService(IUnitOfWork unit, IMapper mapper)
    {
        _unit = unit;
        _foodRepository = unit.FoodRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<FoodModel>> GetAllAsync()
    {
        var foods = await _foodRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<FoodModel>>(foods);
    }

    public async Task<FoodModel> GetByIdAsync(int id)
    {
        var food = await _foodRepository.GetByIdAsync(id);
        return _mapper.Map<FoodModel>(food);
    }

    public async Task<bool> AddAsync(FoodModel model)
    {
        var food = _mapper.Map<Food>(model);
        return await _foodRepository.AddAsync(food);
    }

    public async Task<bool> UpdateAsync(FoodModel model)
    {
        var currentFood = await _foodRepository.GetByIdAsync(model.Id);
        if (currentFood == null)
        {
            return false;
        }

        _mapper.Map(model, currentFood);
        return await _foodRepository.UpdateAsync(currentFood);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _foodRepository.DeleteAsync(id);
    }
}