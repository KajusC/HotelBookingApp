namespace HotelBookingApp.Data.Interfaces;

public interface IUnitOfWork
{
    
    IUserRepository UserRepository { get; }
    IFoodRepository FoodRepository { get; }
    IHotelRepository HotelRepository { get; }
    IOrderRepository OrderRepository { get; }
    IRoomRepository RoomRepository { get; }
    IRoomTypeRepository RoomTypeRepository { get; }
    Task SaveChangesAsync();
}