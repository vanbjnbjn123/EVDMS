using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace EVDMS.Application.Interfaces;

/// <summary>
/// Specification pattern interface for building complex queries in a composable way.
/// Allows for reusable, testable, and maintainable query logic.
/// </summary>
/// <typeparam name="T">Entity type</typeparam>
public interface ISpecification<T>
{
    /// <summary>
    /// Gets the criteria expression for filtering entities
    /// </summary>
    Expression<Func<T, bool>>? Criteria { get; }
    
    /// <summary>
    /// Gets the list of include expressions for eager loading related entities
    /// </summary>
    List<Expression<Func<T, object>>> Includes { get; }
    
    /// <summary>
    /// Gets the list of include string expressions for eager loading related entities
    /// </summary>
    List<string> IncludeStrings { get; }
    
    /// <summary>
    /// Gets the order by expression
    /// </summary>
    Expression<Func<T, object>>? OrderBy { get; }
    
    /// <summary>
    /// Gets the order by descending expression
    /// </summary>
    Expression<Func<T, object>>? OrderByDescending { get; }
    
    /// <summary>
    /// Gets the group by expression
    /// </summary>
    Expression<Func<T, object>>? GroupBy { get; }
    
    /// <summary>
    /// Gets the number of records to take (for pagination)
    /// </summary>
    int? Take { get; }
    
    /// <summary>
    /// Gets the number of records to skip (for pagination)
    /// </summary>
    int? Skip { get; }
    
    /// <summary>
    /// Gets whether paging is enabled
    /// </summary>
    bool IsPagingEnabled { get; }
    
    /// <summary>
    /// Gets whether to track changes for the query
    /// </summary>
    bool AsNoTracking { get; }
    
    /// <summary>
    /// Gets whether to include soft deleted entities
    /// </summary>
    bool IgnoreQueryFilters { get; }
}

/// <summary>
/// Base specification class providing common functionality for building specifications
/// </summary>
/// <typeparam name="T">Entity type</typeparam>
public abstract class BaseSpecification<T> : ISpecification<T>
{
    protected BaseSpecification()
    {
        Includes = new List<Expression<Func<T, object>>>();
        IncludeStrings = new List<string>();
    }
    
    protected BaseSpecification(Expression<Func<T, bool>> criteria) : this()
    {
        Criteria = criteria;
    }

    public Expression<Func<T, bool>>? Criteria { get; private set; }
    public List<Expression<Func<T, object>>> Includes { get; }
    public List<string> IncludeStrings { get; }
    public Expression<Func<T, object>>? OrderBy { get; private set; }
    public Expression<Func<T, object>>? OrderByDescending { get; private set; }
    public Expression<Func<T, object>>? GroupBy { get; private set; }
    public int? Take { get; private set; }
    public int? Skip { get; private set; }
    public bool IsPagingEnabled { get; private set; }
    public bool AsNoTracking { get; private set; }
    public bool IgnoreQueryFilters { get; private set; }

    protected virtual void AddInclude(Expression<Func<T, object>> includeExpression)
    {
        Includes.Add(includeExpression);
    }
    
    protected virtual void AddInclude(string includeString)
    {
        IncludeStrings.Add(includeString);
    }
    
    protected virtual void ApplyOrderBy(Expression<Func<T, object>> orderByExpression)
    {
        OrderBy = orderByExpression;
    }
    
    protected virtual void ApplyOrderByDescending(Expression<Func<T, object>> orderByDescExpression)
    {
        OrderByDescending = orderByDescExpression;
    }
    
    protected virtual void ApplyGroupBy(Expression<Func<T, object>> groupByExpression)
    {
        GroupBy = groupByExpression;
    }
    
    protected virtual void ApplyPaging(int skip, int take)
    {
        Skip = skip;
        Take = take;
        IsPagingEnabled = true;
    }
    
    protected virtual void ApplyNoTracking()
    {
        AsNoTracking = true;
    }
    
    protected virtual void ApplyIgnoreQueryFilters()
    {
        IgnoreQueryFilters = true;
    }
}