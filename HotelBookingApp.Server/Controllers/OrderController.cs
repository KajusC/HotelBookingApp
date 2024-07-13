using HotelBookingApp.Business.DTO;
using HotelBookingApp.Business.DTO.ManyToMany;
using HotelBookingApp.Business.Interfaces;
using HotelBookingApp.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingApp.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;
    private readonly IRoomService _roomService;
    private readonly IFoodService _foodService;
    private readonly ILogger<OrderController> _logger;

    public OrderController(IOrderService orderService, ILogger<OrderController> logger, IRoomService roomService, IFoodService foodService)
    {
        _orderService = orderService;
        _logger = logger;
        _roomService = roomService;
        _foodService = foodService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrders()
    {
        var orders = await _orderService.GetAllAsync();
        return Ok(orders);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<OrderDto>> GetOrderById(int id)
    {
        var order = await _orderService.GetByIdAsync(id);
        if (order == null)
        {
            return NotFound();
        }
        return Ok(order);
    }

    [HttpPost]
    public async Task<ActionResult> AddOrder([FromBody] OrderDto order, [FromQuery] int foodId = 0, [FromQuery] int roomId = 0)
    {
        if (order == null)
        {
            _logger.LogWarning("Order is null");
            return BadRequest();
        }

        await _orderService.AddAsync(order);
        

        if (foodId == 0 && roomId == 0)
        {
            return Ok();
        }
        var orderList = await _orderService.GetAllAsync();
        var last = orderList.MaxBy(o => o.Id).Id;

        await _foodService.JoinFoodWithOrder(foodId, last);
        await _roomService.JoinRoomWithOrder(roomId, last);

        return Ok();
    }


    [HttpPut("{id}")]
    public async Task<ActionResult> EditOrder(int id, [FromBody] OrderDto order)
    {
        if (order == null)
        {
            _logger.LogWarning("Order is null");
            return BadRequest();
        }
        var existingOrder = await _orderService.GetByIdAsync(id);
        if (existingOrder == null)
        {
            _logger.LogWarning($"Order with id {id} not found");
            return NotFound();
        }

        order.Id = id;


        await _orderService.UpdateAsync(order);
            return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteOrder(int id)
    {
        await _orderService.DeleteAsync(id);
            return Ok();

    }

    [HttpGet("customer/{customerId}")]
    public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrdersByCustomerId(int customerId)
    {
        var orders = await _orderService.GetOrdersByCustomerId(customerId);
        return Ok(orders);
    }


}