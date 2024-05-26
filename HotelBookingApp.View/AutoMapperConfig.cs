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
        CreateMap<RoomOrder, RoomOrderModel>()
            .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.OrderId))
            .ForMember(dest => dest.RoomId, opt => opt.MapFrom(src => src.RoomId))
            .ReverseMap();
        CreateMap<FoodHotel, FoodHotelModel>()
            .ForMember(dest => dest.FoodId, opt => opt.MapFrom(src => src.FoodId))
            .ForMember(dest => dest.HotelId, opt => opt.MapFrom(src => src.HotelId))
            .ReverseMap();
        CreateMap<FoodOrder, FoodOrderModel>()
            .ForMember(dest => dest.FoodId, opt => opt.MapFrom(src => src.FoodId))
            .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.OrderId))
            .ReverseMap();
        CreateMap<RoomHotel, RoomHotelModel>()
            .ForMember(dest => dest.RoomId, opt => opt.MapFrom(src => src.RoomId))
            .ForMember(dest => dest.HotelId, opt => opt.MapFrom(src => src.HotelId))
            .ReverseMap();

        CreateMap<Food, FoodModel>()
            .ForMember(dest => dest.FoodHotelIds, opt => opt.MapFrom(src => src.FoodHotels.Select(fh => fh.Id)))
            .ForMember(dest => dest.FoodOrderIds, opt => opt.MapFrom(src => src.FoodOrders.Select(i => i.Id)))
            .ReverseMap();

        CreateMap<Hotel, HotelModel>()
            .ForMember(dest => dest.RoomHotelIds, opt => opt.MapFrom(src => src.RoomHotels.Select(i => i.Id)))
            .ForMember(dest => dest.FoodHotelIds, opt => opt.MapFrom(src => src.FoodHotels.Select(i => i.Id)))
            .ForMember(dest => dest.OrderIds, opt => opt.MapFrom(src => src.Orders.Select(i => i.Id)))
            .ReverseMap();
        CreateMap<Order, OrderModel>()
            .ForMember(dest => dest.FoodOrderIds, opt => opt.MapFrom(src => src.FoodOrders.Select(i => i.Id)))
            .ForMember(dest => dest.RoomOrderIds, opt => opt.MapFrom(src => src.RoomOrders.Select(i => i.Id)))
            .ReverseMap();
        CreateMap<Room, RoomModel>()
            .ForMember(dest => dest.RoomHotelIds, opt => opt.MapFrom(src => src.RoomHotels.Select(i => i.Id)))
            .ForMember(dest => dest.RoomOrderIds, opt => opt.MapFrom(src => src.RoomOrders.Select(i => i.Id)))
            .ReverseMap();

        CreateMap<RoomType, RoomTypeModel>()
            .ForMember(dest => dest.RoomIds, opt => opt.MapFrom(src => src.Rooms.Select(i => i.Id)))
            .ReverseMap();
        CreateMap<User, UserModel>()
            .ForMember(dest => dest.OrderIds, opt => opt.MapFrom(src => src.Orders.Select(i => i.Id)))
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))

            .ReverseMap();

    }
}