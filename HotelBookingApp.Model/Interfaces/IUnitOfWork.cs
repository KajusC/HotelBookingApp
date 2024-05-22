namespace HotelBookingApp.Model.Interfaces;

public interface IUnitOfWork
{
    
    ICustomerRepository Customers { get; }
    IFoodRepository Foods { get; }
    IFoodCategoryRepository FoodCategories { get; }
    IHotelRepository Hotels { get; }
    IOrderRepository Orders { get; }
    IRoomRepository Rooms { get; }
    IRoomTypeRepository RoomTypes { get; }
    Task SaveChangesAsync();
}