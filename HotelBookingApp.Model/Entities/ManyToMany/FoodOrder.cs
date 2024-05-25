namespace HotelBookingApp.Data.Entities.ManyToMany;

public class FoodOrder : BaseEntity
{
    public int FoodId { get; set; }
    public Food Food { get; set; }

    public int OrderId { get; set; }
    public Order Order { get; set; }
}