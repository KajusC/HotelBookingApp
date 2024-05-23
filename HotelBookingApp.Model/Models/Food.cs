using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingApp.Data.Models;

public class Food : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string ImageUrl { get; set; }
    
    public int FoodCategoryId { get; set; }
    public ICollection<Order> Orders { get; set; } = new List<Order>();
    public ICollection<Hotel> Hotels { get; set; } = new List<Hotel>();
}