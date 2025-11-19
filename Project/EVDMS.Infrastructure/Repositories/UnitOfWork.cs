using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using EVDMS.Application.Interfaces;
using EVDMS.Infrastructure.DBContext;
using EVDMS.Infrastructure.Repositories;

namespace EVDMS.Infrastructure.Repositories;

/// <summary>
/// Unit of Work implementation using Entity Framework Core.
/// Manages repositories and database transactions for coordinated data operations.
/// </summary>
public class UnitOfWork : IUnitOfWork
{
    private readonly EVDMSDBContext _context;
    private readonly Dictionary<Type, object> _repositories;
    private IDbContextTransaction? _transaction;
    private bool _disposed = false;

    public UnitOfWork(EVDMSDBContext context)
    {
        _context = context;
        _repositories = new Dictionary<Type, object>();
    }

    /// <summary>
    /// Gets or creates a repository for the specified entity type
    /// </summary>
    /// <typeparam name="T">Entity type</typeparam>
    /// <returns>Generic repository for the entity type</returns>
    public IRepository<T> Repository<T>() where T : class
    {
        var type = typeof(T);
        
        if (_repositories.ContainsKey(type))
        {
            return (IRepository<T>)_repositories[type];
        }

        var repository = new Repository<T>(_context);
        _repositories.Add(type, repository);
        
        return repository;
    }

    /// <summary>
    /// Saves all changes made in this unit of work to the database
    /// </summary>
    /// <returns>Number of affected records</returns>
    public async Task<int> SaveChangesAsync()
    {
        try
        {
            return await _context.SaveChangesAsync();
        }
        catch (DbUpdateException ex)
        {
            throw new InvalidOperationException("An error occurred while saving changes to the database.", ex);
        }
    }

    /// <summary>
    /// Begins a database transaction
    /// </summary>
    public async Task BeginTransactionAsync()
    {
        if (_transaction != null)
        {
            throw new InvalidOperationException("A transaction is already in progress.");
        }

        _transaction = await _context.Database.BeginTransactionAsync();
    }

    /// <summary>
    /// Commits the current transaction
    /// </summary>
    public async Task CommitTransactionAsync()
    {
        if (_transaction == null)
        {
            throw new InvalidOperationException("No transaction in progress to commit.");
        }

        try
        {
            await _transaction.CommitAsync();
        }
        catch (Exception ex)
        {
            await RollbackTransactionAsync();
            throw new InvalidOperationException("An error occurred while committing the transaction.", ex);
        }
        finally
        {
            await _transaction.DisposeAsync();
            _transaction = null;
        }
    }

    /// <summary>
    /// Rolls back the current transaction
    /// </summary>
    public async Task RollbackTransactionAsync()
    {
        if (_transaction == null)
        {
            throw new InvalidOperationException("No transaction in progress to rollback.");
        }

        try
        {
            await _transaction.RollbackAsync();
        }
        finally
        {
            await _transaction.DisposeAsync();
            _transaction = null;
        }
    }

    /// <summary>
    /// Executes a function within a transaction scope
    /// </summary>
    /// <typeparam name="T">Return type</typeparam>
    /// <param name="operation">Function to execute</param>
    /// <returns>Result of the operation</returns>
    public async Task<T> ExecuteInTransactionAsync<T>(Func<Task<T>> operation)
    {
        if (operation == null)
        {
            throw new ArgumentNullException(nameof(operation));
        }

        var wasTransactionStarted = _transaction == null;
        
        if (wasTransactionStarted)
        {
            await BeginTransactionAsync();
        }

        try
        {
            var result = await operation();
            
            if (wasTransactionStarted)
            {
                await CommitTransactionAsync();
            }
            
            return result;
        }
        catch (Exception)
        {
            if (wasTransactionStarted)
            {
                await RollbackTransactionAsync();
            }
            throw;
        }
    }

    /// <summary>
    /// Executes an action within a transaction scope
    /// </summary>
    /// <param name="operation">Action to execute</param>
    public async Task ExecuteInTransactionAsync(Func<Task> operation)
    {
        if (operation == null)
        {
            throw new ArgumentNullException(nameof(operation));
        }

        await ExecuteInTransactionAsync(async () =>
        {
            await operation();
            return true;
        });
    }

    /// <summary>
    /// Disposes of the unit of work and its resources
    /// </summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Protected dispose method
    /// </summary>
    /// <param name="disposing">Whether disposing managed resources</param>
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed && disposing)
        {
            if (_transaction != null)
            {
                _transaction.Dispose();
                _transaction = null;
            }

            _repositories.Clear();
            _disposed = true;
        }
    }
}