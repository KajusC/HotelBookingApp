using System.Data.Entity.ModelConfiguration.Conventions;
using AutoMapper;
using HotelBookingApp.Business.DTO;
using HotelBookingApp.Data.Models;

namespace HotelBookingApp.Business;

public class AutoMapper : Profile
{
    public AutoMapper()
    {

        CreateMap<Customer, CustomerModel>()
            .ForMember(dest => dest.OrderIds, opt => opt.MapFrom(src => src.Orders.Select(o => o.Id)))
            .ReverseMap();

        CreateMap<Food, FoodModel>()
            .ForMember(dest => dest.OrderIds, opt => opt.MapFrom(src => src.Orders.Select(o => o.Id)))
            .ForMember(dest => dest.HotelIds, opt => opt.MapFrom(src => src.Hotels.Select(h => h.Id)))
            .ReverseMap();

        CreateMap<Hotel, HotelModel>()
            .ForMember(dest => dest.RoomIds, opt => opt.MapFrom(src => src.Rooms.Select(r => r.Id)))
            .ForMember(dest => dest.OrderIds, opt => opt.MapFrom(src => src.Orders.Select(o => o.Id)))
            .ForMember(dest => dest.FoodIds, opt => opt.MapFrom(src => src.Foods.Select(f => f.Id)))
            .ReverseMap();

        CreateMap<Order, OrderModel>()
            .ForMember(dest => dest.RoomIds, opt => opt.MapFrom(src => src.Rooms.Select(r => r.Id)))
            .ForMember(dest => dest.FoodIds, opt => opt.MapFrom(src => src.Foods.Select(f => f.Id)))
            .ReverseMap();

        CreateMap<Room, RoomModel>()
            .ForMember(dest => dest.OrderIds, opt => opt.MapFrom(src => src.Orders.Select(o => o.Id)))
            .ReverseMap();

        CreateMap<RoomType, RoomTypeModel>()
            .ForMember(dest => dest.RoomIds, opt => opt.MapFrom(src => src.Rooms.Select(r => r.Id)))
            .ReverseMap();
    }
}