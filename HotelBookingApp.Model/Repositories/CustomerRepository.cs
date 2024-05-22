using HotelBookingApp.Model.Data;
using HotelBookingApp.Model.Interfaces;
using HotelBookingApp.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApp.Model.Repositories;

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
        throw new NotImplementedException();
    }

    public async Task<Customer> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> AddAsync(Customer entity)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> UpdateAsync(Customer entity)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}