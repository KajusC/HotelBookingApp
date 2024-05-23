namespace HotelBookingApp.Business.Interfaces;

public interface ICrud<TModel> where TModel : class
{
    Task<IEnumerable<TModel>> GetAllAsync();
    Task<TModel> GetByIdAsync(int id);
    Task<bool> AddAsync(TModel model);
    Task<bool> UpdateAsync(int id, TModel model);
    Task<bool> DeleteAsync(int id);
}