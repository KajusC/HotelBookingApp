using HotelBookingApp.Model.Interfaces;
using HotelBookingApp.Model.Repositories;

namespace HotelBookingApp.Model.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly HotelDataContext _context;
    private IRoomTypeRepository _roomTypeRepository;
    private IRoomRepository _roomRepository;
    private IOrderRepository _orderRepository;

    public UnitOfWork(HotelDataContext context)
    {
        _context = context;
    }

    public void Save()
    {
        _context.SaveChanges();
    }

    public ICustomerRepository Customers { get; }
    public IFoodRepository Foods { get; }
    public IFoodCategoryRepository FoodCategories { get; }
    public IHotelRepository Hotels { get; }
    public IOrderRepository Orders { get; }
    public IRoomRepository Rooms { get; }
    public IRoomTypeRepository RoomTypes { get; }
    public async Task SaveChangesAsync()
    {
        throw new NotImplementedException();
    }
}