using shop.domain.Extensions;
using shop.domain.Interfaces.Repositories;
using shop.domain.Interfaces.Services;

namespace shop.service.Services;

public abstract class BaseService<TModel> : IService<TModel> where TModel : class
{
    private readonly IRepository<TModel> _repository;

    protected BaseService(IRepository<TModel> repository)
    {
        _repository = repository;
    }

    public virtual async Task<TModel?> GetById(int id) => await _repository.Select(id);

    public virtual async Task<TModel> Add(TModel newModel) => await _repository.Insert(newModel);

    public virtual async Task<TModel?> Update(int id, TModel newModel)
    {
        var oldModel = await _repository.Select(id);

        if (oldModel.IsNotNull())
        {
            oldModel.ReceiveDifferentProperties(newModel);
            return await _repository.Update(oldModel);
        }

        return null;
    }

    public virtual async Task<TModel?> Delete(int id)
    {
        var deletedModel = await _repository.Select(id);

        if (deletedModel.IsNotNull())
            await _repository.Delete(deletedModel);

        return deletedModel;
    }
}
