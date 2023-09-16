namespace shop.domain.Interfaces.Services;

public interface IService<TModel> where TModel : class
{
    public Task<TModel?> GetById(int id);

    public Task<TModel> Add(TModel model);

    public Task<TModel?> Update(int id, TModel model);

    public Task<TModel?> Delete(int id);
}