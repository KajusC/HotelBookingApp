using HotelBookingApp.Data.Data;
using HotelBookingApp.Data.Entities.ManyToMany;
using HotelBookingApp.Data.Interfaces.ManyToMany;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApp.Data.Repositories;

public class RoomOrderRepository : GeneralRepository<RoomOrder>, IRoomOrderRepository
{
    public RoomOrderRepository(HotelDataContext context) : base(context)
    {
    }

    public override async Task<IEnumerable<RoomOrder>> GetAllAsync()
    {
        return await _dbSet
            .Include(ro => ro.Room)
            .Include(ro => ro.Order)
            .ToListAsync();
    }
    public override async Task<RoomOrder> GetByIdAsync(int id)
    {
        return await _dbSet
            .Include(ro => ro.Room)
            .Include(ro => ro.Order)
            .FirstOrDefaultAsync(ro => ro.Id == id) ?? throw new ArgumentException("RoomOrder with this id does not exist");
    }
}