using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EVDMS.Application.Interfaces;

/// <summary>
/// Generic repository interface providing standard CRUD operations and query capabilities.
/// Supports async operations and flexible querying with specifications pattern.
/// </summary>
/// <typeparam name="T">Entity type that implements base entity interface</typeparam>
public interface IRepository<T> where T : class
{
    // Basic CRUD Operations
    Task<T?> GetByIdAsync(Guid id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> AddAsync(T entity);
    Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);
    Task<T> UpdateAsync(T entity);
    Task DeleteAsync(Guid id);
    Task DeleteAsync(T entity);
    Task DeleteRangeAsync(IEnumerable<T> entities);
    
    // Query Operations
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
    Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
    Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate);
    Task<int> CountAsync();
    Task<int> CountAsync(Expression<Func<T, bool>> predicate);
    
    // Transaction Support
    Task<int> SaveChangesAsync();
    
    // Specification Pattern Support
    // Task<IEnumerable<T>> GetBySpecificationAsync(ISpecification<T> specification);
    // Task<T?> FirstOrDefaultBySpecificationAsync(ISpecification<T> specification);
    // Task<int> CountBySpecificationAsync(ISpecification<T> specification);
}