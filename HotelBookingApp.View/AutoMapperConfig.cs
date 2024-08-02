using AutoMapper;
using HotelBookingApp.Business.DTO;
using HotelBookingApp.Business.DTO.ManyToMany;
using HotelBookingApp.Data.Entities;
using HotelBookingApp.Data.Entities.ManyToMany;

namespace HotelBookingApp.Business;

public class AutoMapperConfig : Profile
{
    public AutoMapperConfig()
    {
        CreateMap<RoomOrder, RoomOrderDto>()
            .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.OrderId))
            .ForMember(dest => dest.RoomId, opt => opt.MapFrom(src => src.RoomId))
            .ReverseMap();
        CreateMap<FoodHotel, HotelFoodDto>()
            .ForMember(dest => dest.FoodId, opt => opt.MapFrom(src => src.FoodId))
            .ForMember(dest => dest.HotelId, opt => opt.MapFrom(src => src.HotelId))
            .ReverseMap();
        CreateMap<FoodOrder, OrderFoodDto>()
            .ForMember(dest => dest.FoodId, opt => opt.MapFrom(src => src.FoodId))
            .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.OrderId))
            .ReverseMap();
        CreateMap<RoomHotel, HotelRoomDto>()
            .ForMember(dest => dest.RoomId, opt => opt.MapFrom(src => src.RoomId))
            .ForMember(dest => dest.HotelId, opt => opt.MapFrom(src => src.HotelId))
            .ReverseMap();

        CreateMap<Food, FoodDto>()
            .ForMember(dest => dest.FoodHotelIds, opt => opt.MapFrom(src => src.FoodHotels.Select(fh => fh.Id)))
            .ForMember(dest => dest.FoodOrderIds, opt => opt.MapFrom(src => src.FoodOrders.Select(i => i.Id)))
            .ReverseMap();

        CreateMap<Hotel, HotelDto>()
            .ForMember(dest => dest.RoomHotelIds, opt => opt.MapFrom(src => src.RoomHotels.Select(i => i.Id)))
            .ForMember(dest => dest.FoodHotelIds, opt => opt.MapFrom(src => src.FoodHotels.Select(i => i.Id)))
            .ForMember(dest => dest.OrderIds, opt => opt.MapFrom(src => src.Orders.Select(i => i.Id)))
            .ReverseMap();
        CreateMap<Order, OrderDto>()
            .ForMember(dest => dest.FoodOrderIds, opt => opt.MapFrom(src => src.FoodOrders.Select(i => i.Id)))
            .ForMember(dest => dest.RoomOrderIds, opt => opt.MapFrom(src => src.RoomOrders.Select(i => i.Id)))
            .ReverseMap();
        CreateMap<Room, RoomDto>()
            .ForMember(dest => dest.RoomHotelIds, opt => opt.MapFrom(src => src.RoomHotels.Select(i => i.Id)))
            .ForMember(dest => dest.RoomOrderIds, opt => opt.MapFrom(src => src.RoomOrders.Select(i => i.Id)))
            .ReverseMap();

        CreateMap<RoomType, RoomTypeDto>()
            .ForMember(dest => dest.RoomIds, opt => opt.MapFrom(src => src.Rooms.Select(i => i.Id)))
            .ReverseMap();
        CreateMap<User, UserDto>()
            .ForMember(dest => dest.OrderIds, opt => opt.MapFrom(src => src.Orders.Select(i => i.Id)))
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))

            .ReverseMap();

    }
}