namespace HotelBookingApp.Model.Models;

public class Order : BaseEntity
{
    public int RoomId { get; set; }
    public Room Room { get; set; }
    public int FoodId { get; set; }
    public Food Food { get; set; }
    public int Quantity { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
    public string Status { get; set; }

    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
}