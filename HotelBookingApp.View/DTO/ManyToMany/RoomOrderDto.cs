namespace HotelBookingApp.Business.DTO.ManyToMany;

public class RoomOrderDto
{
    public int Id { get; set; }
    public int RoomId { get; set; }
    public int OrderId { get; set; }
}