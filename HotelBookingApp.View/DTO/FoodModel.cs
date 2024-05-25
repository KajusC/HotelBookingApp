using HotelBookingApp.Data.Entities.ManyToMany;

namespace HotelBookingApp.Business.DTO;

public class FoodModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string ImageUrl { get; set; }

    public ICollection<int> FoodHotelIds { get; set; } = new List<int>();
    public ICollection<int> FoodOrderIds { get; set; } = new List<int>();
}