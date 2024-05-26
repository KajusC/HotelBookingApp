using HotelBookingApp.Data.Data;
using HotelBookingApp.Data.Interfaces;
using HotelBookingApp.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApp.Data.Repositories;

public class OrderRepository : GeneralRepository<Order> , IOrderRepository
{
    public OrderRepository(HotelDataContext context) : base(context)
    {
    }

    public override async Task<IEnumerable<Order>> GetAllAsync()
    {
        return await _dbSet
            .Include(o => o.RoomOrders)
            .Include(o => o.FoodOrders)
            .ToListAsync();
    }

    public override async Task<Order> GetByIdAsync(int id)
    {
        return await _dbSet
            .Include(o => o.RoomOrders)
            .Include(o => o.FoodOrders)
            .FirstOrDefaultAsync(o => o.Id == id);
    }

}