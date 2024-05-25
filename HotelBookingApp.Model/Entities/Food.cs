using System.ComponentModel.DataAnnotations.Schema;
using HotelBookingApp.Data.Entities.ManyToMany;

namespace HotelBookingApp.Data.Entities;

public class Food : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string ImageUrl { get; set; }
    
    public ICollection<FoodHotel> FoodHotels { get; set; } = new List<FoodHotel>();
    public ICollection<FoodOrder> FoodOrders { get; set; } = new List<FoodOrder>();

}