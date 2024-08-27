using AutoMapper;
using HotelBookingApp.Business.DTO;
using HotelBookingApp.Business.Interfaces;
using HotelBookingApp.Business.Validity;
using HotelBookingApp.Data.Interfaces;
using HotelBookingApp.Data.Entities;
using Microsoft.Extensions.Logging;
using HotelBookingApp.Data.Entities.ManyToMany;
using HotelBookingApp.Data.Interfaces.ManyToMany;
using HotelBookingApp.Data.Repositories;

namespace HotelBookingApp.Business.Services;

public class RoomService : IRoomService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger<RoomDto> _logger;

    private readonly IRoomRepository _roomRepository;
    private readonly IOrderRepository _orderRepository;
    private readonly IRoomOrderRepository _roomOrderRepository;
    private readonly IHotelRepository _hotelRepository;
    private readonly IRoomHotelRepository _roomHotelRepository;
    public RoomService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<RoomDto> logger)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _logger = logger;

        _roomRepository = unitOfWork.RoomRepository;
        _orderRepository = unitOfWork.OrderRepository;
        _roomOrderRepository = unitOfWork.RoomOrderRepository;
        _hotelRepository = unitOfWork.HotelRepository;
        _roomHotelRepository = unitOfWork.RoomHotelRepository;
    }

    public async Task<IEnumerable<RoomDto>> GetAllAsync()
    {
        var entities = await _roomRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<RoomDto>>(entities);
    }

    public async Task<RoomDto> GetByIdAsync(int id)
    {
        var entity = await _roomRepository.GetByIdAsync(id);
        return _mapper.Map<RoomDto>(entity);
    }

    public async Task AddAsync(RoomDto model)
    {
        var entity = _mapper.Map<Room>(model);
        await _roomRepository.AddAsync(entity);
    }

    public async Task UpdateAsync(RoomDto model)
    {
        var entity = _mapper.Map<Room>(model);
        await _roomRepository.UpdateAsync(entity);
    }

    public async Task DeleteAsync(int modelId)
    {
        var entity = await _roomRepository.GetByIdAsync(modelId);
        await _roomRepository.DeleteAsync(entity);
    }

    public async Task JoinRoomWithOrder(int roomId, int orderId)
    {
        var room = await _roomRepository.GetByIdAsync(roomId);
        if (room == null)
        {
            throw new ServiceException($"room with Id {roomId} does not exist.");
        }

        var order = await _orderRepository.GetByIdAsync(orderId);
        if (order == null)
        {
            throw new ServiceException($"order with Id {orderId} does not exist.");
        }

        var roomOrder = new RoomOrder()
        {
            RoomId = roomId,
            Room = room,
            OrderId = orderId,
            Order = order,
        };

        room.RoomOrders.Add(roomOrder);
        await _roomRepository.UpdateAsync(room);

        order.RoomOrders.Add(roomOrder);
        await _orderRepository.UpdateAsync(order);

        await _roomOrderRepository.AddAsync(roomOrder);
    }

    public async Task<IEnumerable<RoomDto>> GetRoomsByHotelId(int hotelId)
    {
        var rooms = await _roomRepository.GetAllAsync();
        var filtered = rooms.Where(h => h.RoomHotels.Any(rh => rh.HotelId == hotelId));
        return _mapper.Map<IEnumerable<RoomDto>>(filtered);
    }

    public async Task JoinRoomsWithHotel(int roomId, int hotelId)
    {
        var hotel = await _hotelRepository.GetByIdAsync(hotelId);
        if (hotel == null)
        {
            throw new ServiceException($"Hotel with Id {hotelId} does not exist.");
        }
        
        var room = await _roomRepository.GetByIdAsync(roomId);
        if (room == null)
        {
            throw new ServiceException($"Room with Id {roomId} does not exist.");
        }

        var roomHotel = new RoomHotel
        {
            RoomId = roomId,
            Room = room,
            HotelId = hotelId,
            Hotel = hotel,
        };

        hotel.HotelRooms.Add(roomHotel);
        await _hotelRepository.UpdateAsync(hotel);

        room.RoomHotels.Add(roomHotel);
        await _roomRepository.UpdateAsync(room);

        await _roomHotelRepository.AddAsync(roomHotel);
    }
}
