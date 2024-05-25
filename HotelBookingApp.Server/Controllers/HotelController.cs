using HotelBookingApp.Business.DTO;
using HotelBookingApp.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingApp.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class HotelController : ControllerBase
{
    private readonly IHotelService _hotelService;
    private readonly ILogger<HotelController> _logger;

    public HotelController(IHotelService hotelService, ILogger<HotelController> logger)
    {
        _hotelService = hotelService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<HotelModel>>> GetHotels()
    {
        var hotels = await _hotelService.GetAllAsync();
        return Ok(hotels);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<HotelModel>> GetHotelById(int id)
    {
        var hotel = await _hotelService.GetByIdAsync(id);
        if (hotel == null)
        {
            _logger.LogWarning($"Hotel with id {id} not found");
            return NotFound();
        }
        return Ok(hotel);
    }

    [HttpGet("Foods/{id}")]
    public async Task<ActionResult<int>> GetHotelsFoodsById(int id)
    {
        var hotel = await _hotelService.GetByIdAsync(id);
        if (hotel == null)
        {
            _logger.LogWarning($"Hotel with id {id} not found");
            return NotFound();
        }
        var foods = hotel.FoodIds.First();
        return Ok(foods);
    }

    [HttpPost]
    public async Task<ActionResult> AddHotel([FromBody] HotelModel hotel)
    {
        if (hotel == null)
        {
            _logger.LogWarning("Hotel is null");
            return BadRequest();
        }

        if(await _hotelService.AddAsync(hotel))
            return Ok();
        else
            return BadRequest();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> EditHotel(int id, [FromBody] HotelModel hotel)
    {
        if (hotel == null)
        {
            _logger.LogWarning("Hotel is null");
            return BadRequest();
        }

        var existingHotel = await _hotelService.GetByIdAsync(id);
        if (existingHotel == null)
        {
            _logger.LogWarning($"Hotel with id {id} not found");
            return NotFound();
        }
        hotel.Id = id;

        if(await _hotelService.UpdateAsync(hotel))
            return Ok();
        else
            return BadRequest();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteHotel(int id)
    {
        if(await _hotelService.DeleteAsync(id))
                        return Ok();
        else
        {
            _logger.LogWarning($"Hotel with id {id} not found");
            return BadRequest();
        }
           
    }
}