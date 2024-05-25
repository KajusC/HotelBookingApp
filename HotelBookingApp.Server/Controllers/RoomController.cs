using HotelBookingApp.Business.DTO;
using HotelBookingApp.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingApp.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class RoomController : ControllerBase
{
    private readonly IRoomService _roomService;
    private readonly ILogger<RoomController> _logger;

    public RoomController(IRoomService roomService, ILogger<RoomController> logger)
    {
        _roomService = roomService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<RoomModel>>> GetRooms()
    {
        var rooms = await _roomService.GetAllAsync();
        return Ok(rooms);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<RoomModel>> GetRoomById(int id)
    {
        var room = await _roomService.GetByIdAsync(id);
        if (room == null)
        {
            _logger.LogWarning($"Room with id {id} not found");
            return NotFound();
        }
        return Ok(room);
    }

    [HttpPost]
    public async Task<ActionResult> AddRoom([FromBody] RoomModel room)
    {
        if (room == null)
        {
            _logger.LogWarning("Room is null");
            return BadRequest();
        }

        await _roomService.AddAsync(room);
            return Ok();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> EditRoom(int id, [FromBody] RoomModel room)
    {
        if (room == null)
        {
            _logger.LogWarning("Room is null");
            return BadRequest();
        }
        var existingRoom = await _roomService.GetByIdAsync(id);
        if (existingRoom == null)
        {
            _logger.LogWarning($"Room with id {id} not found");
            return NotFound();
        }
        room.Id = id;


        await _roomService.UpdateAsync(room);
            return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteRoom(int id)
    {
        var room = await _roomService.GetByIdAsync(id);
        if (room == null)
        {
            _logger.LogWarning($"Room with id {id} not found");
            return NotFound();
        }

        await _roomService.DeleteAsync(id);
            return Ok();
    }
}