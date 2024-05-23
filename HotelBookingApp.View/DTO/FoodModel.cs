namespace HotelBookingApp.Business.DTO;

public class FoodModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string ImageUrl { get; set; }
    public int FoodCategoryId { get; set; }
    public ICollection<int>? OrderIds { get; set; }
    public ICollection<int>? HotelIds { get; set; }
}