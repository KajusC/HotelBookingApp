﻿using HotelBookingApp.Business.DTO;
using HotelBookingApp.Business.DTO.ManyToMany;
using HotelBookingApp.Business.Interfaces;
using HotelBookingApp.Business.Services;
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

        await _foodService.AddAsync(food);
            return Ok();
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
    [HttpGet("/Join")]
    public async Task<ActionResult<IEnumerable<FoodHotelModel>>> GetFoodWithHotel()
    {
        var foodHotels = await _foodService.GetAllFoodHotelLinks();

        return Ok(foodHotels);
    }

    [HttpPost("/JoinHotel/{foodId}/{hotelId}")]
    public async Task<ActionResult> JoinFoodWithHotel(int foodId, int hotelId)
    {
        await _foodService.JoinFoodWithHotel(foodId, hotelId);
        return Ok();
    }

    [HttpPost("JoinOrder/{foodId}/{orderId}")]
    public async Task<ActionResult> JoinFoodWithOrder(int foodId, int orderId)
    {
        await _foodService.JoinFoodWithOrder(foodId, orderId);
        return Ok();
    }


}