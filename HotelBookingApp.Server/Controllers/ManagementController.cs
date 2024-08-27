using HotelBookingApp.Business.DTO.ManyToMany;
using HotelBookingApp.Business.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingApp.Server.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ManagementController : ControllerBase
    {

        private readonly IFoodService _foodService;
        private readonly IRoomService _roomService;

        public ManagementController(IFoodService foodService, IRoomService roomService)
        {
            _foodService = foodService;
            _roomService = roomService;
        }

        [HttpGet("/Join")]
        public async Task<ActionResult<IEnumerable<HotelFoodDto>>> GetFoodWithHotel()
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

        [HttpPost("JoinHotel/{RoomId}/{HotelId}")]
        public async Task<ActionResult> JoinRoomAndHotel(int RoomId, int HotelId)
        {
            await _roomService.JoinRoomsWithHotel(RoomId, HotelId);
            return Ok();
        }
    }
}
