namespace HotelBookingApp.Model.Models;

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
    public string ImageUrl { get; set; }
    public List<Room> Rooms { get; set; }
    public List<Food> Foods { get; set; }
    public List<Order> Orders { get; set; }
}