using HotelBookingApp.Business.DTO;
using HotelBookingApp.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingApp.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
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
    public async Task<ActionResult<IEnumerable<HotelDto>>> GetHotels([FromQuery] string countryOrCity = null!)
    {
        if (string.IsNullOrEmpty(countryOrCity))
        {
            var hotels = await _hotelService.GetAllAsync();
            _logger.LogInformation("Getting all hotels");
            return Ok(hotels);
        }
        else
        {
            countryOrCity = countryOrCity.ToLower();
            var hotels = await _hotelService.GetHotelByCountryOrCity(countryOrCity);
            return Ok(hotels);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<HotelDto>> GetHotelById(int id)
    {
        var hotel = await _hotelService.GetByIdAsync(id);
        if (hotel == null)
        {
            _logger.LogWarning($"Hotel with id {id} not found");
            return NotFound();
        }
        return Ok(hotel);
    }
    
    [HttpGet("user/{userId}")]
    public async Task<ActionResult<HotelDto>> GetHotelByUserId(int userId)
    {
        var hotel = await _hotelService.GetHotelByUserId(userId);
        if (hotel == null)
        {
            _logger.LogWarning($"Hotel with user id {userId} not found");
            return NotFound();
        }
        return Ok(hotel);
    }

    [HttpPost]
    public async Task<ActionResult> AddHotel([FromBody] HotelDto hotel)
    {
        if (hotel == null)
        {
            _logger.LogWarning("Hotel is null");
            return BadRequest();
        }

        await _hotelService.AddAsync(hotel);
            return Ok();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> EditHotel(int id, [FromBody] HotelDto hotel)
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

        await _hotelService.UpdateAsync(hotel);
            return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteHotel(int id)
    {
        await _hotelService.DeleteAsync(id);
        return Ok();
           
    }

}