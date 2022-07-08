using Microsoft.EntityFrameworkCore;

namespace DotNetFlix.DbHelpers;

public class DflixRepo<TEntity> where TEntity : class
{
    private readonly DflixContext _context;
    private readonly DbSet<TEntity> _dbSet;

    public DflixRepo(DflixContext context)
    {
        _context = context;
        _dbSet = _context.Set<TEntity>();
    }

    public async Task<TEntity> GetByUserName(int id)
    {
        var model = await _dbSet.FindAsync(id);
        return model;
    }

    public async Task CreateAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
        _context.SaveChanges();
    }

    /*
    public IQueryable<TEntity> GetObjectsQueryable(Expression<Func<TEntity, bool>> predicate, string includeTable = "")
    {
        IQueryable<TEntity> result = _context.Set<TEntity>().Where(predicate);
        if (includeTable != "")
            result = result.Include(includeTable);

        return result;
    }
    */
}
