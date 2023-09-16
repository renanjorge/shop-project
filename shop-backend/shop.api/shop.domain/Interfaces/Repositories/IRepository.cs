namespace shop.domain.Interfaces.Repositories;

public interface IRepository<TEntity> where TEntity : class
{
    Task<TEntity?> Select(int id);

    Task<TEntity> Insert(TEntity entity);

    Task<TEntity> Update(TEntity entity);

    Task Delete(TEntity entity);

    Task<int> Total();

    Task Dispose();
}
