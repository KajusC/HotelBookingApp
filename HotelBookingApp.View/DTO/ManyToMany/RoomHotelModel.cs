namespace HotelBookingApp.Business.DTO.ManyToMany;

public class RoomHotelModel
{
    public int Id { get; set; }
    public int RoomId { get; set; }
    public int HotelId { get; set; }
}