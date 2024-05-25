namespace HotelBookingApp.Data.Entities.ManyToMany;

public class FoodHotel : BaseEntity
{
    public int FoodId { get; set; }
    public Food Food { get; set; }

    public int HotelId { get; set; }
    public Hotel Hotel { get; set; }
}