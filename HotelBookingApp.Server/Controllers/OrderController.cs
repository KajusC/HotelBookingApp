using HotelBookingApp.Business.DTO;
using HotelBookingApp.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingApp.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;
    private readonly ILogger<OrderController> _logger;

    public OrderController(IOrderService orderService, ILogger<OrderController> logger)
    {
        _orderService = orderService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<OrderModel>>> GetOrders()
    {
        var orders = await _orderService.GetAllAsync();
        return Ok(orders);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<OrderModel>> GetOrderById(int id)
    {
        var order = await _orderService.GetByIdAsync(id);
        if (order == null)
        {
            return NotFound();
        }
        return Ok(order);
    }

    [HttpPost]
    public async Task<ActionResult> AddOrder([FromBody] OrderModel order)
    {
        await _orderService.AddAsync(order);
            return Ok();

    }

    [HttpPut("{id}")]
    public async Task<ActionResult> EditOrder(int id, [FromBody] OrderModel order)
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
}