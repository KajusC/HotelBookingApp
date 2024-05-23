namespace HotelBookingApp.Data.Interfaces;

public interface IUnitOfWork
{
    
    ICustomerRepository CustomerRepository { get; }
    IFoodRepository FoodRepository { get; }
    IHotelRepository HotelRepository { get; }
    IOrderRepository OrderRepository { get; }
    IRoomRepository RoomRepository { get; }
    IRoomTypeRepository RoomTypeRepository { get; }
    Task SaveChangesAsync();
}