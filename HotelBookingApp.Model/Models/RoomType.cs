namespace HotelBookingApp.Data.Models;

public class RoomType : BaseEntity
{
    public string Name { get; set; }

    public ICollection<Room> Rooms { get; set; } = new List<Room>();
}