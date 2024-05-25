using AutoMapper;
using HotelBookingApp.Business.DTO;
using HotelBookingApp.Business.Interfaces;
using HotelBookingApp.Data.Interfaces;
using HotelBookingApp.Data.Entities;

namespace HotelBookingApp.Business.Services;

public class HotelService : GeneralService<HotelModel, Hotel>, IHotelService
{
    public HotelService(IHotelRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }

    public async Task<IEnumerable<HotelModel>> GetHotelByFoodInclusion(int foodInclusionId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<HotelModel>> GetHotelByRoomTypes(int roomTypeId)
    {
        throw new NotImplementedException();
    }
}