namespace HotelBookingApp.Data.Entities.ManyToMany;

public class RoomHotel : BaseEntity
{
    public int RoomId { get; set; }
    public Room Room { get; set; }

    public int HotelId { get; set; }
    public Hotel Hotel { get; set; }
}