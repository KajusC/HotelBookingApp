using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingApp.Model.Models;

public class Food : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string ImageUrl { get; set; }

    [ForeignKey("FoodCategoryId")]
    public int FoodCategoryId { get; set; }
    public FoodCategory FoodCategory { get; set; }

    public ICollection<Order> Orders { get; set; }
}