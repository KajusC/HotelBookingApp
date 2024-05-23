using HotelBookingApp.Data.Models;

namespace HotelBookingApp.Business.DTO;

public class HotelModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Website { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public ICollection<int>? RoomIds { get; set; } = new List<int>();
    public ICollection<int>? OrderIds { get; set; } = new List<int>();
    public ICollection<int>? FoodIds { get; set; } = new List<int>();
}