using HotelBookingApp.Business.DTO;
using HotelBookingApp.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingApp.Server.Controllers;

[ApiController]
[Route("[controller]")]
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
    public async Task<ActionResult<IEnumerable<FoodModel>>> GetFoods()
    {
        var foods = await _foodService.GetAllAsync();
        return Ok(foods);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<FoodModel>> GetFoodById(int id)
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
    public async Task<ActionResult> AddFood([FromBody] FoodModel food)
    {
        if (food == null)
        {
            _logger.LogWarning("Food is null");
            return BadRequest();
        }

        if(await _foodService.AddAsync(food))
            return Ok();
        else
            return BadRequest();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> EditFood(int id, [FromBody] FoodModel food)
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

        if(await _foodService.UpdateAsync(food))
            return Ok();
        else
            return BadRequest();
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

        if(await _foodService.DeleteAsync(id))
            return Ok();
        else
            return BadRequest();
    }
}