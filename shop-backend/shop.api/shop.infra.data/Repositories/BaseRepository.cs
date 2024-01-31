using Microsoft.EntityFrameworkCore;
using shop.domain.Entities;
using shop.domain.Interfaces;
using shop.infra.data.Context;

namespace shop.infra.data.Repositories;

public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : Entity
{
    protected readonly ShopContext _context;
    protected readonly DbSet<TEntity> _dbSet;

    protected BaseRepository(ShopContext context)
    {
        _context = context;
        _dbSet = _context.Set<TEntity>();
    }

    public virtual async Task<TEntity?> Select(int id) => await _dbSet.FindAsync(id);

    public virtual async Task<TEntity> Insert(TEntity entity)
    {
        _dbSet.Add(entity);
        await _context.SaveChangesAsync();

        return entity;
    }

    public virtual async Task<TEntity> Update(TEntity entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();

        return entity;
    }

    public virtual async Task Delete(TEntity entity)
    {
        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<int> Total() => await _dbSet.AsTracking().CountAsync();

    public async Task Dispose() => await _context.DisposeAsync();
}
