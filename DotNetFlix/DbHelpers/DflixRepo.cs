using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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
    public async Task DeleteAll()
    {
        await Task.Run(() => {
            _dbSet.RemoveRange(_dbSet.ToList());
            _context.SaveChanges();
        });
    }
    public async Task<List<TEntity>> GetAllAsync()
    {
        return await Task.FromResult(_dbSet.ToList());
    }
    public async Task<TEntity> GetByGuid(Guid? id, string[] paths = null)
    {
        var model = await _dbSet.FindAsync(id);
        foreach (var path in paths)
        {
            _context.Entry(model).Reference(path).Load();
        }
        return model;
    }
    public async Task Update(TEntity entity)
    {
        await Task.Run(() => {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        });
    }
    public async Task<TEntity> GetByStringId(string id)
    {
        var model = await _dbSet.FindAsync(id);
        return model;
    }
    public async Task<TEntity> FindCartByUserIdAsync(Expression<Func<TEntity, bool>> match)
    {
        var model = await _dbSet.SingleOrDefaultAsync(match);
        return model;
    }
    public async Task Add(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
        _context.SaveChanges();
    }
}
