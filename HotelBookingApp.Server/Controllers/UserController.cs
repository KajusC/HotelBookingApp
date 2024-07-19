using HotelBookingApp.Business.DTO;
using HotelBookingApp.Business.Interfaces;
using HotelBookingApp.Data.Interfaces;
using HotelBookingApp.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingApp.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly ILogger _logger;

    public UserController(IUserService userService, ILogger<UserController> logger)
    {
        _userService = userService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDto>>> GetCustomers()
    {
        var customers = await _userService.GetAllAsync();
        return Ok(customers);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserDto>> GetCustomerById(int id)
    {
        var customer = await _userService.GetByIdAsync(id);
        if (customer == null)
        {
            _logger.LogWarning($"User with id {id} not found");
            return NotFound();
        }
        return Ok(customer);
    }

    [HttpPost]
    public async Task<ActionResult> AddCustomer([FromBody] UserDto model)
    {
        await _userService.AddAsync(model);
        return Ok(model);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateCustomer(int id, [FromBody] UserDto model)
    {
        var customer = await _userService.GetByIdAsync(id);
        if (customer == null)
        {
            _logger.LogWarning($"User with id {id} not found");
            return NotFound();
        }

        model.Id = id;

        // Use the existing entity in the update service method
        await _userService.UpdateAsync(customer);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task Delete(int id)
    {
        await _userService.DeleteAsync(id);
    }
}