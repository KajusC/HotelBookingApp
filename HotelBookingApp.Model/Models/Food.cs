using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingApp.Data.Models;

public class Food : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }

    public ICollection<Hotel> Hotels{ get; set; } = new List<Hotel>();
    public ICollection<Order> Orders { get; set; } = new List<Order>();
}