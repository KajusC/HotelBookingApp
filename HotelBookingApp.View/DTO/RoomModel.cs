using HotelBookingApp.Data.Models;

namespace HotelBookingApp.Business.DTO;

public class RoomModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public int Capacity { get; set; }
    public bool IsBooked { get; set; }
    public int HotelId { get; set; }
    public int RoomTypeId { get; set; }
    public ICollection<int> OrderIds { get; set; } = new List<int>();
}