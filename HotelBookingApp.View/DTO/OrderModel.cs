using HotelBookingApp.Data.Entities;
using HotelBookingApp.Data.Entities.ManyToMany;

namespace HotelBookingApp.Business.DTO;

public class OrderModel
{
    public int Id { get; set; }
    public int Quantity { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
    public string Status { get; set; }
    public int HotelId { get; set; }
    public int CustomerId { get; set; }
    public ICollection<int> FoodOrderIds { get; set; } = new List<int>();
    public ICollection<int> RoomOrderIds { get; set; } = new List<int>();
}