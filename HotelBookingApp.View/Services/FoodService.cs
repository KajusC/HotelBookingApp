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

    public async Task AddAsync(FoodModel model)
    {
        var food = _mapper.Map<Food>(model);
        await _foodRepository.AddAsync(food);
        await _unit.SaveChangesAsync();
    }

    public async Task UpdateAsync(FoodModel model)
    {
        var currentFood = await _foodRepository.GetByIdAsync(model.Id);
        if (currentFood == null)
        {
            return;
        }

        _mapper.Map(model, currentFood);
        await _foodRepository.UpdateAsync(currentFood);
        await _unit.SaveChangesAsync();
    }

    public async Task DeleteAsync(int modelId)
    {
        await _foodRepository.DeleteByIdAsync(modelId);
        await _unit.SaveChangesAsync();
    }
}