using System;
using System.Threading.Tasks;

namespace EVDMS.Application.Interfaces;

/// <summary>
/// Unit of Work pattern interface for managing database transactions and repositories.
/// Provides a single point for coordinating work across multiple repositories.
/// </summary>
public interface IUnitOfWork : IDisposable
{
    /// <summary>
    /// Gets a repository for the specified entity type
    /// </summary>
    /// <typeparam name="T">Entity type</typeparam>
    /// <returns>Generic repository for the entity type</returns>
    IRepository<T> Repository<T>() where T : class;

    /// <summary>
    /// Saves all changes made in this unit of work to the database
    /// </summary>
    /// <returns>Number of affected records</returns>
    Task<int> SaveChangesAsync();

    /// <summary>
    /// Begins a database transaction
    /// </summary>
    Task BeginTransactionAsync();

    /// <summary>
    /// Commits the current transaction
    /// </summary>
    Task CommitTransactionAsync();

    /// <summary>
    /// Rolls back the current transaction
    /// </summary>
    Task RollbackTransactionAsync();

    /// <summary>
    /// Executes a function within a transaction scope
    /// Automatically commits on success or rolls back on exception
    /// </summary>
    /// <typeparam name="T">Return type</typeparam>
    /// <param name="operation">Function to execute</param>
    /// <returns>Result of the operation</returns>
    Task<T> ExecuteInTransactionAsync<T>(Func<Task<T>> operation);

    /// <summary>
    /// Executes an action within a transaction scope
    /// Automatically commits on success or rolls back on exception
    /// </summary>
    /// <param name="operation">Action to execute</param>
    Task ExecuteInTransactionAsync(Func<Task> operation);
}