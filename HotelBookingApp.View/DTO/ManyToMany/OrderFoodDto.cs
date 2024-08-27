namespace HotelBookingApp.Business.DTO.ManyToMany;

public class OrderFoodDto
{
    public int Id { get; set; }
    public int FoodId { get; set; }
    public int OrderId { get; set; }
}