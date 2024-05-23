using HotelBookingApp.Data.Models;

namespace HotelBookingApp.Business.DTO;

public class OrderModel
{
    public int Id { get; set; }
    public int RoomId { get; set; }
    public int FoodId { get; set; }
    public int Quantity { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
    public string? Status { get; set; }
    public int CustomerId { get; set; }

    public ICollection<int> RoomIds { get; set; } = new List<int>();
    public ICollection<int> FoodIds { get; set; } = new List<int>();
}