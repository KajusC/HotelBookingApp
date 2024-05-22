namespace HotelBookingApp.Model.Models;

public class Room : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int RoomTypeId { get; set; }
    public RoomType RoomType { get; set; }
    public int Price { get; set; }
    public int Capacity { get; set; }
    public bool IsBooked { get; set; }

    public ICollection<Order> Orders { get; set; }

    public int HotelId { get; set; }
    public Hotel Hotel { get; set; }
}