using HotelBookingApp.Data.Models;

namespace HotelBookingApp.Business.DTO;

public class RoomTypeModel
{
    public int Id { get; set; }
    public string Name { get; set; }

    public ICollection<int> RoomIds { get; set; }
}