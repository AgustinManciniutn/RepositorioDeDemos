using Microsoft.EntityFrameworkCore;
using sigmaHashAlpha.Core.Repositories;
using sigmaHashAlpha.Data;
using System.Data.SqlClient;
namespace sigmaHashAlpha.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected ApplicationDbContext _context;
    protected DbSet<T> dbSet;
    protected readonly ILogger _logger;


    public GenericRepository(
        ApplicationDbContext context, ILogger logger)
    {
        _context = context;
        _logger = logger;
        dbSet = context.Set<T>();
    }

    public async Task<List<T>> GetAll()
    {

        try
        {
            var list = await dbSet.ToListAsync();
            if(list != null)
            {
                _context.DetachAllEntities();
                return list;
            }
            else
            {
                _context.DetachAllEntities();
                return new List<T>();
            }
        }
        catch
        {
            return new List<T>();
        }
    }

    public async Task<T> GetById(string id)
    {
        try
        {
            var obj = await dbSet.FindAsync(id);
            _context.Entry(obj).State = EntityState.Detached;
            return obj;
        }
        catch
        {
            return null;
        }
        
    }

    public async Task<bool> Add(T entity)
    {
        await dbSet.AddAsync(entity);
        return true;
    }
    public async Task<bool> Update(T entity, T obj)
    {
        _context.Entry(obj).CurrentValues.SetValues(entity);
        await _context.SaveChangesAsync();
        await _context.SaveChangesAsync();
        return true;
    }
    public async Task<bool> Delete(string id)
    {
        try
        {
            var obj = await dbSet.FindAsync(id);
            if(obj !=null)
            {
                dbSet.Remove(obj!);
                return true;
            }
            return false;
        }

        catch(Exception ex)
        {
            _logger.LogError(ex, "Generic Delete method error");
            return false;
        }
    }

    public async Task<bool> Upsert(T entity, string id)
    {
        //try
        //{
            var obj = await dbSet.FindAsync(id);
            if (obj == null)
            {
                await Add(entity);
            }
            else
            {
                await Update(entity,obj);
            }
            return true;
        //}
        //catch(Exception ex)
        //{
        //    _logger.LogError(ex, "{Repo} Upsert method error", typeof(T));
        //    return false;
        //}

    }


}
