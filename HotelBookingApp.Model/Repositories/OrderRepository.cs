using HotelBookingApp.Model.Data;
using HotelBookingApp.Model.Interfaces;
using HotelBookingApp.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApp.Model.Repositories;

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

    public async Task<bool> AddAsync(Order entity)
    {
        await _orders.AddAsync(entity);
        return await _hotelDataContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> UpdateAsync(Order entity)
    {
        _orders.Update(entity);
        return await _hotelDataContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var order = await GetByIdAsync(id);
        _orders.Remove(order);
        return await _hotelDataContext.SaveChangesAsync() > 0;  
    }
}