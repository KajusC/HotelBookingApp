using HotelBookingApp.Business.DTO;
using HotelBookingApp.Business.DTO.ManyToMany;
using HotelBookingApp.Business.Interfaces;
using HotelBookingApp.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingApp.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FoodController : ControllerBase
{
    private readonly IFoodService _foodService;
    private readonly ILogger<FoodController> _logger;

    public FoodController(IFoodService foodService, ILogger<FoodController> logger)
    {
        _foodService = foodService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<FoodDto>>> GetFoods()
    {
        var foods = await _foodService.GetAllAsync();
        return Ok(foods);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<FoodDto>> GetFoodById(int id)
    {
        var food = await _foodService.GetByIdAsync(id);
        if (food == null)
        {
            _logger.LogWarning($"Food with id {id} not found");
            return NotFound();
        }
        return Ok(food);
    }

    [HttpPost]
    public async Task<ActionResult> AddFood([FromBody] FoodDto food)
    {
        if (food == null)
        {
            _logger.LogWarning("Food is null");
            return BadRequest();
        }

        await _foodService.AddAsync(food);
            return Ok();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> EditFood(int id, [FromBody] FoodDto food)
    {
        if (food == null)
        {
            _logger.LogWarning("Food is null");
            return BadRequest();
        }

        var existingFood = await _foodService.GetByIdAsync(id);
        if (existingFood == null)
        {
            _logger.LogWarning($"Food with id {id} not found");
            return NotFound();
        }
        food.Id = id;

        await _foodService.UpdateAsync(food);
            return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteFood(int id)
    {
        var food = await _foodService.GetByIdAsync(id);
        if (food == null)
        {
            _logger.LogWarning($"Food with id {id} not found");
            return NotFound();
        }

        await _foodService.DeleteAsync(id);
            return Ok();
    }
}