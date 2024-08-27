using HotelBookingApp.Business.DTO;
using HotelBookingApp.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingApp.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
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
    public async Task<ActionResult<IEnumerable<RoomDto>>> GetRooms([FromQuery] int HotelId = 0)
    {
        if (HotelId == 0)
        {
            var rooms = await _roomService.GetAllAsync();
            return Ok(rooms);
        }
        else
        {
            var rooms = await _roomService.GetRoomsByHotelId(HotelId);
            return Ok(rooms);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<RoomDto>> GetRoomById(int id)
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
    public async Task<ActionResult> AddRoom([FromBody] RoomDto room)
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
    public async Task<ActionResult> EditRoom(int id, [FromBody] RoomDto room)
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

    [HttpPost("JoinOrder/{roomId}/{orderId}")]
    public async Task<ActionResult> JoinRoomAndOrder(int roomId, int orderId)
    {
        await _roomService.JoinRoomWithOrder(roomId, orderId);
        return Ok();
    }
    [HttpPost("JoinHotel/{RoomId}/{HotelId}")]
    public async Task<ActionResult> JoinRoomAndHotel(int RoomId, int HotelId)
    {
        await _roomService.JoinRoomsWithHotel(RoomId, HotelId);
        return Ok();
    }

}