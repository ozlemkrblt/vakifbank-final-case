using ECommerce.Data.Repository;
using ECommerce.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ECommerce.Data.Context;

namespace ECommerce.Data.Repository;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseModel
{
    private readonly ECommerceDbContext dbContext;

    public GenericRepository(ECommerceDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    //Soft deletion methods are named Delete(), to permanently delete entity and its relations  
    public void Delete(TEntity entity)
    {
        entity.IsActive = false;
        entity.UpdateDate = DateTime.UtcNow;
        entity.UpdateUserId = 1;
        dbContext.Set<TEntity>().Update(entity);
    }


    public void Delete(int id)
    {
        var entity = dbContext.Set<TEntity>().Find(id);
        entity.IsActive = false;
        entity.UpdateDate = DateTime.UtcNow;
        entity.UpdateUserId = 1;
        dbContext.Set<TEntity>().Update(entity);
    }

    public List<TEntity> GetAll(params string[] includes)
    {
        var query = dbContext.Set<TEntity>().AsQueryable();
        if (includes.Any())
        {
            query = includes.Aggregate(query, (current, incl) => current.Include(incl));
        }
        return query.ToList();
    }

    public IQueryable<TEntity> GetAsQueryable(params string[] includes)
    {
        var query = dbContext.Set<TEntity>().AsQueryable();
        if (includes.Any())
        {
            query = includes.Aggregate(query, (current, incl) => current.Include(incl));
        }
        return query;
    }

    public IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> expression, params string[] includes)
    {
        var query = dbContext.Set<TEntity>().AsQueryable();
        query.Where(expression);
        if (includes.Any())
        {
            query = includes.Aggregate(query, (current, incl) => current.Include(incl));
        }
        return query.ToList();
    }

    public TEntity GetById(int id, params string[] includes)
    {
        var query = dbContext.Set<TEntity>().AsQueryable();
        if (includes.Any())
        {
            query = includes.Aggregate(query, (current, incl) => current.Include(incl));
        }
        return query.FirstOrDefault(x => x.Id == id);
    }

    public async Task<TEntity> GetByIdAsync(int id, CancellationToken cancellationToken, params string[] includes)
    {
        var query = dbContext.Set<TEntity>().AsQueryable();
        if (includes.Any())
        {
            query = includes.Aggregate(query, (current, incl) => current.Include(incl));
        }
        return await query.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public void Update(TEntity entity) //update shouldn't be in the repository pattern 
    {

    }
    public void Insert(TEntity entity)  
    {
        entity.InsertDate = DateTime.UtcNow;
        entity.InsertUserId = 1;
        entity.IsActive = true;
        dbContext.Set<TEntity>().Add(entity);
    }

    public void InsertRange(List<TEntity> entities)
    {
        entities.ForEach(x =>
        {
            x.InsertUserId = 1;
            x.InsertDate = DateTime.UtcNow;
            x.IsActive = true;
        });
        dbContext.Set<TEntity>().AddRange(entities);
    }

    //Hard deletion methods are named Remove(), to permanently delete entity and its relations  
    public void Remove(TEntity entity)
    {
        dbContext.Set<TEntity>().Remove(entity);
        dbContext.SaveChanges();
    }

    public void Remove(int id)
    {
        var entity = dbContext.Set<TEntity>().Find(id);
        if (entity != null)
        {
            dbContext.Set<TEntity>().Remove(entity);
            dbContext.SaveChanges();
        }
    }
}
