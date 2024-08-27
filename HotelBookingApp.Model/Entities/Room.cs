using HotelBookingApp.Data.Entities.ManyToMany;

namespace HotelBookingApp.Data.Entities;

public class Room : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public int Capacity { get; set; }
    public int BedCount { get; set; }
    public bool IsBooked { get; set; }
    public int RoomTypeId { get; set; }
    public RoomType RoomType { get; set; }

    public ICollection<RoomHotel> RoomHotels { get; set; } = new List<RoomHotel>();
    public ICollection<RoomOrder> RoomOrders { get; set; } = new List<RoomOrder>();
}