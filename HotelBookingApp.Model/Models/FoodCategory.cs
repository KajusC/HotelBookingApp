namespace HotelBookingApp.Model.Models;

public class FoodCategory : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }

    public ICollection<Food> Foods { get; set; }
}