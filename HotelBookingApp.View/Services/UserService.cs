using AutoMapper;
using HotelBookingApp.Business.DTO;
using HotelBookingApp.Business.Interfaces;
using HotelBookingApp.Data.Data;
using HotelBookingApp.Data.Interfaces;
using HotelBookingApp.Data.Entities;
using System.Reflection;
using HotelBookingApp.Business.Validity;

namespace HotelBookingApp.Business.Services;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unit;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(IUnitOfWork unit, IMapper mapper)
    {
        _unit = unit;
        _userRepository = unit.UserRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<UserModel>> GetAllAsync()
    {
        var customers = await _userRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<UserModel>>(customers);
    }

    public async Task<UserModel> GetByIdAsync(int id)
    {
        var customer = await _userRepository.GetByIdAsync(id);
        return _mapper.Map<UserModel>(customer);
    }

    public async Task AddAsync(UserModel model)
    {
        var customer = _mapper.Map<User>(model);
        var result = await _userRepository.AddAsync(customer);
    }

    public async Task UpdateAsync(UserModel user)
    {
        if (user == null)
        {
            throw new ArgumentNullException(nameof(user));
        }

        var existingCustomer = await _userRepository.GetByIdAsync(user.Id);
        if (existingCustomer == null)
        {
            throw new ServiceException($"User with Id {user.Id} does not exist.");
        }

        _mapper.Map(user, existingCustomer);

        var updateResult = await _userRepository.UpdateAsync(existingCustomer);

    }

    public async Task DeleteAsync(int id)
    {
        var result = await _userRepository.DeleteAsync(id);
    }
}