using HotelBookingApp.Data.Interfaces;
using HotelBookingApp.Data.Interfaces.ManyToMany;
using HotelBookingApp.Data.Repositories;

namespace HotelBookingApp.Data.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly HotelDataContext _context;

    public UnitOfWork(HotelDataContext hotelDataContext, IUserRepository user, IFoodRepository food, 
        IHotelRepository hotel, IOrderRepository order, IRoomRepository room, IRoomTypeRepository roomType,
        IFoodHotelRepository foodHotel, IFoodOrderRepository foodOrder, IRoomOrderRepository roomOrder, IRoomHotelRepository roomHotelRepository)
    {
        _context = hotelDataContext;
        UserRepository = user;
        FoodRepository = food;
        HotelRepository = hotel;
        OrderRepository = order;
        RoomRepository = room;
        RoomTypeRepository = roomType;
        FoodHotelRepository = foodHotel;
        FoodOrderRepository = foodOrder;
        RoomOrderRepository = roomOrder;
        RoomHotelRepository = roomHotelRepository;
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public IUserRepository UserRepository { get; }
    public IFoodRepository FoodRepository { get; }
    public IHotelRepository HotelRepository { get; }
    public IOrderRepository OrderRepository { get; }
    public IRoomRepository RoomRepository { get; }
    public IRoomTypeRepository RoomTypeRepository { get; }

    public IFoodHotelRepository FoodHotelRepository { get; }
    public IFoodOrderRepository FoodOrderRepository { get; }
    public IRoomOrderRepository RoomOrderRepository { get; }
    public IRoomHotelRepository RoomHotelRepository { get; }

}