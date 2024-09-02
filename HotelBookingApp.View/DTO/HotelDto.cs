using HotelBookingApp.Data.Entities;
using HotelBookingApp.Data.Entities.ManyToMany;

namespace HotelBookingApp.Business.DTO;

public class HotelDto
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
    public double Rating { get; set; }
    public string ImageUrl { get; set; }
    public int? UserId { get; set; }
    public int MinBedCount { get; set; }
    public int MaxBedCount { get; set; }
    public int minGuestCount { get; set; }
    public int maxGuestCount { get; set; }
    public double AveragePrice { get; set; }

    public ICollection<int> RoomHotelIds { get; set; } = new List<int>();
    public ICollection<int> FoodHotelIds { get; set; } = new List<int>();
    public ICollection<int> OrderIds { get; set; } = new List<int>();
}