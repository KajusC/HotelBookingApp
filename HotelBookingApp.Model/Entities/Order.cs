using System.Runtime.CompilerServices;
using HotelBookingApp.Data.Entities.ManyToMany;

namespace HotelBookingApp.Data.Entities;

public class Order : BaseEntity
{
    public double Price { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
    public string Status { get; set; }
    public int HotelId { get; set; }
    public Hotel Hotel { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public ICollection<FoodOrder> FoodOrders { get; set; } = new List<FoodOrder>();
    public ICollection<RoomOrder> RoomOrders { get; set; } = new List<RoomOrder>();
}