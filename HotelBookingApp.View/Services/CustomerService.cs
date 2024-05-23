using AutoMapper;
using HotelBookingApp.Business.DTO;
using HotelBookingApp.Business.Interfaces;
using HotelBookingApp.Data.Data;
using HotelBookingApp.Data.Interfaces;
using HotelBookingApp.Data.Models;
using System.Reflection;
using HotelBookingApp.Business.Validity;

namespace HotelBookingApp.Business.Services;

public class CustomerService : ICustomerService
{
    private readonly IUnitOfWork _unit;
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public CustomerService(IUnitOfWork unit, IMapper mapper)
    {
        _unit = unit;
        _customerRepository = unit.CustomerRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<CustomerModel>> GetAllAsync()
    {
        var customers = await _customerRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<CustomerModel>>(customers);
    }

    public async Task<CustomerModel> GetByIdAsync(int id)
    {
        var customer = await _customerRepository.GetByIdAsync(id);
        return _mapper.Map<CustomerModel>(customer);
    }

    public async Task<bool> AddAsync(CustomerModel model)
    {
        var customer = _mapper.Map<Customer>(model);
        var result = await _customerRepository.AddAsync(customer);
        return result;
    }

    public async Task<bool> UpdateAsync(int id, CustomerModel customer)
    {
        if (customer == null)
        {
            throw new ArgumentNullException(nameof(customer));
        }

        var existingCustomer = await _customerRepository.GetByIdAsync(id);
        if (existingCustomer == null)
        {
            throw new ServiceException($"Customer with Id {customer.Id} does not exist.");
        }

        _mapper.Map(customer, existingCustomer);

        var updateResult = await _customerRepository.UpdateAsync(existingCustomer);

        // Check if the update was successful
        return updateResult;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var result = await _customerRepository.DeleteAsync(id);
        return result;
    }
}