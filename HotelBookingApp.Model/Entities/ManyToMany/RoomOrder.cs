namespace HotelBookingApp.Data.Entities.ManyToMany;

public class RoomOrder : BaseEntity
{
    public int RoomId { get; set; }
    public Room Room { get; set; }

    public int OrderId { get; set; }
    public Order Order { get; set; }
}