using System.Linq.Expressions;
using InternProject.Application.Interfaces;
using InternProject.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace InternProject.Persistence.Repositories;

public class GenericRepository <T>: IGenericRepository<T> where T: class
{
    private readonly ApplicationContext _applicationContext;
    private readonly DbSet<T> _dbSet;

    public GenericRepository( ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
        _dbSet = _applicationContext.Set<T>();

    }
    
    public async Task<T?> GetByIdAsync(int id)
    {
        //  return entity ?? throw new InvalidOperationException();
        return await _dbSet.FindAsync(id);
    }

    public IQueryable<T> GetAll(Expression<Func<T, bool>> expression)
    {
        return _dbSet.AsNoTracking().AsQueryable();
        // memorye almadan kullanmak için
    }

    public IQueryable<T> Where(Expression<Func<T, bool>> expression)
    {
        return _dbSet.Where(expression);
    }

    public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
    {
        return await _dbSet.AnyAsync(expression);
    }

    public async Task<T> AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _applicationContext.SaveChangesAsync();
        return entity;
    }

    public async Task AddRangeAsync(IEnumerable<T> entities)
    {
        await _dbSet.AddRangeAsync(entities);
    }

    public async Task Update(T entity)
    {
        _dbSet.Update(entity);
        await _applicationContext.SaveChangesAsync();
    }

    public async Task Remove(T entity)
    {
        
       await  _applicationContext.SaveChangesAsync();
        // entity state = deleted işaretliyoruz
    }

    public Task RemoveRange(IEnumerable<T> entities)
    {
        _dbSet.RemoveRange(entities);
        return Task.CompletedTask;
        // for each ile entity lerde donuyor her entity nin state ini deleted olarak işaretliyor.
    }
}