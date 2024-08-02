using HotelBookingApp.Data.Interfaces.ManyToMany;

namespace HotelBookingApp.Data.Interfaces;

public interface IUnitOfWork
{
    
    IUserRepository UserRepository { get; }
    IFoodRepository FoodRepository { get; }
    IHotelRepository HotelRepository { get; }
    IOrderRepository OrderRepository { get; }
    IRoomRepository RoomRepository { get; }
    IRoomTypeRepository RoomTypeRepository { get; }
    IFoodHotelRepository FoodHotelRepository { get; }
    IFoodOrderRepository FoodOrderRepository { get; }
    IRoomOrderRepository RoomOrderRepository { get; }
    IRoomHotelRepository RoomHotelRepository { get; }
    Task SaveChangesAsync();
}