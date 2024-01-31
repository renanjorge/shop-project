using shop.domain.Entities;

namespace shop.domain.Interfaces;

public interface IRepository<TEntity> where TEntity : Entity
{
    Task<TEntity?> Select(int id);

    Task<TEntity> Insert(TEntity entity);

    Task<TEntity> Update(TEntity entity);

    Task Delete(TEntity entity);

    Task<int> Total();

    Task Dispose();
}
