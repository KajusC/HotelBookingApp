using HotelBookingApp.Data.Data;
using HotelBookingApp.Data.Interfaces;
using HotelBookingApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApp.Data.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly DbSet<Customer> _customerSet;
    private readonly HotelDataContext _context;


    public CustomerRepository(HotelDataContext dataContext)
    {
        _context = dataContext;
        _customerSet = dataContext.Customers;
    }

    public async Task<IEnumerable<Customer>> GetAllAsync()
    {
        return await _customerSet.ToListAsync();
    }

    public async Task<Customer> GetByIdAsync(int id)
    {
        return await _customerSet.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<bool> AddAsync(Customer entity)
    {
        await _customerSet.AddAsync(entity);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> UpdateAsync(Customer entity)
    {
        _customerSet.Update(entity);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var customer = await GetByIdAsync(id);
        _customerSet.Remove(customer);
        return await _context.SaveChangesAsync() > 0;
    }
}