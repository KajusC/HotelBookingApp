using AutoMapper;
using HotelBookingApp.Business.Interfaces;
using HotelBookingApp.Data.Entities;
using HotelBookingApp.Data.Interfaces;

namespace HotelBookingApp.Business.Services;

public class GeneralService<TEntityModel, TEntity> : ICrud<TEntityModel>
    where TEntityModel : class
    where TEntity : BaseEntity
{

    private readonly IRepository<TEntity> _repository;
    private readonly IMapper _mapper;

    public GeneralService(IRepository<TEntity> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TEntityModel>> GetAllAsync()
    {

        var entities = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<TEntityModel>>(entities);
    }

    public async Task<TEntityModel> GetByIdAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(id);
        return _mapper.Map<TEntityModel>(entity);
    }

    public async Task AddAsync(TEntityModel model)
    {
        var entity = _mapper.Map<TEntity>(model);
        await _repository.AddAsync(entity);
    }

    public async Task UpdateAsync(TEntityModel model)
    {
        var entity = _mapper.Map<TEntity>(model);
        await _repository.UpdateAsync(entity);
    }

    public async Task DeleteAsync(int modelId)
    {
        await _repository.DeleteAsync(modelId);
    }
}
