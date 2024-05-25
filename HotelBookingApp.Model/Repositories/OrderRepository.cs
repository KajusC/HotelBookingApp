using HotelBookingApp.Data.Data;
using HotelBookingApp.Data.Interfaces;
using HotelBookingApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApp.Data.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly DbSet<Order> _orders;
    private readonly HotelDataContext _hotelDataContext;

    public OrderRepository(HotelDataContext hotelDataContext)
    {
        _hotelDataContext = hotelDataContext;
        _orders = hotelDataContext.Orders;
    }

    public async Task<IEnumerable<Order>> GetAllAsync()
    {
        return await _orders.ToListAsync();
    }

    public async Task<Order> GetByIdAsync(int id)
    {
        return await _orders.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task AddAsync(Order entity)
    {
        await _orders.AddAsync(entity);
        await _hotelDataContext.SaveChangesAsync();
    }

    public async Task Delete(Order entity)
    {
        _orders.Remove(entity);
        await _hotelDataContext.SaveChangesAsync();
    }

    public async Task DeleteByIdAsync(int id)
    {
        var order = await GetByIdAsync(id);
        if (order == null) return;

        _orders.Remove(order);
        await _hotelDataContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Order entity)
    {
        _orders.Update(entity);
        await _hotelDataContext.SaveChangesAsync();
    }

    public async Task<Order> GetOrdersWithDetailsAsync()
    {
        return await _orders
            .Include(o => o.Foods)
            .Include(o => o.Rooms)
            .Include(o => o.User)
            .FirstOrDefaultAsync();
    }

    public async Task<Order> GetOrderWithDetailsAsyncById(int id)
    {
        return await _orders
            .Include(o => o.Foods)
            .Include(o => o.Rooms)
            .Include(o => o.User)
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}