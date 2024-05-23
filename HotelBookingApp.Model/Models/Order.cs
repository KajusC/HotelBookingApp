namespace HotelBookingApp.Data.Models;

public class Order : BaseEntity
{
    public int HotelId { get; set; }
    public Hotel Hotel { get; set; }
    public int Quantity { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
    public string Status { get; set; }
    public int CustomerId { get; set; }
    public User User { get; set; }
    public ICollection<Food> Foods { get; set; } = new List<Food>();
    public ICollection<Room> Rooms { get; set; } = new List<Room>();
}