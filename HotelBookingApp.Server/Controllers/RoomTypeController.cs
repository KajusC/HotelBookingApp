using HotelBookingApp.Business.DTO;
using HotelBookingApp.Business.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomTypeController : ControllerBase
    {
        private readonly IRoomTypeService _roomTypeService;
        private readonly ILogger<RoomTypeController> _logger;

        public RoomTypeController(IRoomTypeService roomTypeService, ILogger<RoomTypeController> logger)
        {
            _roomTypeService = roomTypeService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomTypeModel>>> GetRoomTypes()
        {
            var roomTypes = await _roomTypeService.GetAllAsync();
            return Ok(roomTypes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RoomTypeModel>> GetRoomTypeById(int id)
        {
            var roomType = await _roomTypeService.GetByIdAsync(id);
            if (roomType == null)
            {
                _logger.LogWarning($"RoomType with id {id} not found");
                return NotFound();
            }
            return Ok(roomType);
        }

        [HttpPost]
        public async Task<ActionResult> AddRoomType([FromBody] RoomTypeModel roomType)
        {
            if (roomType == null)
            {
                _logger.LogWarning("RoomType is null");
                return BadRequest();
            }

            await _roomTypeService.AddAsync(roomType);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> EditRoomType(int id, [FromBody] RoomTypeModel roomType)
        {
            if (roomType == null)
            {
                _logger.LogWarning("RoomType is null");
                return BadRequest();
            }

            var existingRoomType = await _roomTypeService.GetByIdAsync(id);
            if (existingRoomType == null)
            {
                _logger.LogWarning($"RoomType with id {id} not found");
                return NotFound();
            }

            await _roomTypeService.UpdateAsync(roomType);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRoomType(int id)
        {
            var existingRoomType = await _roomTypeService.GetByIdAsync(id);
            if (existingRoomType == null)
            {
                _logger.LogWarning($"RoomType with id {id} not found");
                return NotFound();
            }

            await _roomTypeService.DeleteAsync(id);
            return Ok();
        }
    }
}
