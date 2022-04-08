using System.Linq.Expressions;
using ProTechniqueInfrastructure.Core.Entities;

namespace ProTechniqueInfrastructure.Core.DataAccess;

public interface IEntityRepository<TEntity> where TEntity: class, IEntity, new()
{
    TEntity Get(Expression<Func<TEntity, bool>> filter);
    Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter);
    ICollection<TEntity> GetAll(Expression<Func<TEntity, bool>>? filter = null);
    Task<ICollection<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? filter = null);
    void Add(TEntity entity);
    Task AddAsync(TEntity entity);
    void Update(TEntity entity);
    Task UpdateAsync(TEntity entity);
    void Delete(TEntity entity);
    Task DeleteAsync(TEntity entity);
}