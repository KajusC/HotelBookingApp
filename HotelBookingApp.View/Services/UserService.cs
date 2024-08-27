using AutoMapper;
using HotelBookingApp.Business.DTO;
using HotelBookingApp.Business.Interfaces;
using HotelBookingApp.Data.Data;
using HotelBookingApp.Data.Interfaces;
using HotelBookingApp.Data.Entities;
using System.Reflection;
using HotelBookingApp.Business.Validity;
using Microsoft.Extensions.Logging;

namespace HotelBookingApp.Business.Services;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger<UserDto> _logger;

    private readonly IUserRepository _userRepository;

    public UserService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UserDto> logger)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _logger = logger;

        _userRepository = unitOfWork.UserRepository;
    }
    public async Task<IEnumerable<UserDto>> GetAllAsync()
    {
        var customers = await _userRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<UserDto>>(customers);
    }

    public async Task<UserDto> GetByIdAsync(int id)
    {
        var customer = await _userRepository.GetByIdAsync(id);
        return _mapper.Map<UserDto>(customer);
    }

    public async Task AddAsync(UserDto model)
    {
        var customer = _mapper.Map<User>(model);
        var result = await _userRepository.AddAsync(customer);
    }

    public async Task UpdateAsync(UserDto user)
    {
        ArgumentNullException.ThrowIfNull(user);

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