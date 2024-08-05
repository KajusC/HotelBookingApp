using HotelBookingApp.Data.Entities.ManyToMany;

namespace HotelBookingApp.Data.Entities;

public class Hotel : BaseEntity
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Website { get; set; }
    public string Description { get; set; }
    public double Rating { get; set; }
    public string ImageUrl { get; set; }

    public ICollection<FoodHotel> HotelFoods { get; set; } = new List<FoodHotel>();
    public ICollection<Order> Orders { get; set; } = new List<Order>();
    public ICollection<RoomHotel> HotelRooms { get; set; } = new List<RoomHotel>();
}