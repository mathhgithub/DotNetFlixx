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

    public async Task DeleteAll()
    {
        await Task.Run(() => {
            _dbSet.RemoveRange(_dbSet.ToList());
            _context.SaveChanges();
        });
    }

}
