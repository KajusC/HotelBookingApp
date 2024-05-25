using HotelBookingApp.Data.Entities;

namespace HotelBookingApp.Business.DTO;

public class RoomTypeModel
{
    public int Id { get; set; }
    public string Name { get; set; }

    public ICollection<int> RoomIds { get; set; } = new List<int>();
}