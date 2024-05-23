using HotelBookingApp.Data.Interfaces;
using HotelBookingApp.Data.Repositories;

namespace HotelBookingApp.Data.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly HotelDataContext _context;

    public UnitOfWork(HotelDataContext context)
    {
        _context = context;
        CustomerRepository = new CustomerRepository(context);
        FoodRepository = new FoodRepository(context);
        HotelRepository = new HotelRepository(context);
        OrderRepository = new OrderRepository(context);
        RoomRepository = new RoomRepository(context);
        RoomTypeRepository = new RoomTypeRepository(context);

    }

    public async Task SaveChangesAsync()
    { 
        await _context.SaveChangesAsync();
    }

    public ICustomerRepository CustomerRepository { get; } 
    public IFoodRepository FoodRepository { get; }
    public IHotelRepository HotelRepository { get; }
    public IOrderRepository OrderRepository { get; }
    public IRoomRepository RoomRepository { get; }
    public IRoomTypeRepository RoomTypeRepository { get; }
}