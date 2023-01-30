using System.Linq.Expressions;

namespace InternProject.Application.Interfaces;

public interface IGenericRepository <T> where T: class
{
    Task<T?> GetByIdAsync(int id);
    
    IQueryable<T> GetAll(Expression<Func<T, bool>> expression);

    IQueryable<T> Where(Expression<Func<T, bool>> expression);
    
    Task<bool> AnyAsync(Expression<Func<T, bool>> expression);

    Task<T> AddAsync(T entity);

    Task AddRangeAsync(IEnumerable<T> entities);
    
    Task Update(T entity);
    
    Task Remove(T entity);

    Task RemoveRange(IEnumerable<T> entities);

}