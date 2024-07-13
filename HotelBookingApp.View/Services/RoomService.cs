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

public class RoomService : GeneralService<RoomDto, Room>, IRoomService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IRoomOrderRepository _roomOrderRepository;
    private readonly IHotelRepository _hotelRepository;
    private readonly IRoomHotelRepository _roomHotelRepository;
    public RoomService(IRoomRepository repository, IMapper mapper, ILogger<RoomDto> logger, IRoomHotelRepository roomHotelRepository,
                    IOrderRepository orderRepository, IRoomOrderRepository roomOrderRepository, IHotelRepository hotelRepository) : base(repository, mapper, logger)
    {
        _orderRepository = orderRepository;
        _roomOrderRepository = roomOrderRepository;
        _hotelRepository = hotelRepository;
        _roomHotelRepository = roomHotelRepository;
    }

    public async Task JoinRoomWithOrder(int roomId, int orderId)
    {
        var room = await _repository.GetByIdAsync(roomId);
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
        await _repository.UpdateAsync(room);
        

        order.RoomOrders.Add(roomOrder);
        await _orderRepository.UpdateAsync(order);

        await _roomOrderRepository.AddAsync(roomOrder);
    }

    public async Task<IEnumerable<RoomDto>> GetRoomsByHotelId(int hotelId)
    {
        var rooms = await _repository.GetAllAsync();
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
        
        var room = await _repository.GetByIdAsync(roomId);
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

        hotel.RoomHotels.Add(roomHotel);
        await _hotelRepository.UpdateAsync(hotel);

        room.RoomHotels.Add(roomHotel);
        await _repository.UpdateAsync(room);

        await _roomHotelRepository.AddAsync(roomHotel);


    }
}
