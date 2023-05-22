﻿using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using System.Reflection;

namespace WorldCitiesAPI.Data;

public class ApiResult<T>
{
    /// <summary>
    /// Private constructor called by the CreateAsync
    /// </summary>
    private ApiResult(List<T> data, int count, int pageIndex, int pageSize, string? sortColumn, string? sortOrder)
    {
        Data = data;
        PageIndex = pageIndex;
        PageSize = pageSize;
        TotalCount = count;
        TotalPages = (int)Math.Ceiling(count / (double)pageSize);
    }

    #region Methods
    /// <summary>
    /// Pages and/or sorts a IQueryable source.
    /// </summary>
    /// <param name="source">An IQueryable source of generic type</param>
    /// <param name="pageIndex">Zero-based current page index (0 = first page)</param>
    /// <param name="pageSize">The actual size of each page</param>
    /// <param name="sortColumn">The sorting column name</param>
    /// <param name="sortOrder">The sorting order ("ASC" or "DESC")</param>
    /// <returns>
    /// A object containing the paged result
    /// and all the relevant pageing navigation info.
    /// </returns>
     public static async Task<ApiResult<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize, string? sortColumn = null, string? sortOrder = null)
    {
        var count = await source.CountAsync();

        if(!string.IsNullOrEmpty(sortColumn) && IsValidProperty(sortColumn))
        {
            sortOrder = !string.IsNullOrEmpty(sortOrder) && sortOrder.ToUpper() == "ASC" ? "ASC" : "DESC";
            source = source.OrderBy(string.Format("{0} {1}", sortColumn, sortOrder));
        }
        source = source
            .Skip(pageIndex * pageSize)
            .Take(pageSize);

        var data = await source.ToListAsync();

        return new ApiResult<T>(data, count, pageIndex, pageSize, sortColumn, sortOrder);
    }

    /// <summary>
    /// Checks if the given property name exists to protect against SQL injection attacks
    /// </summary>
    public static bool IsValidProperty(string propertyName, bool throwExceptionIfNotFound = true)
    {
        var prop = typeof(T).GetProperty(propertyName,
            BindingFlags.IgnoreCase |
            BindingFlags.Public |
            BindingFlags.Instance);
        if (prop == null && throwExceptionIfNotFound)
            throw new NotSupportedException(string.Format($"Error: Property '{propertyName}' dow not exist"));
        return prop != null;
    }
    #endregion

    #region Properties
    /// <summary>
    /// The data result.
    /// </summary>
    public List<T> Data { get; private set; }

    /// <summary>
    /// Zero-based index of current page.
    /// </summary>
    public int PageIndex { get; private set; }

    /// <summary>
    /// Number of items contained in each page.
    /// </summary>
    public int PageSize { get; private set; }

    /// <summary>
    /// Total items count
    /// </summary>
    public int TotalCount { get; private set; }

    /// <summary>
    /// Total pages count
    /// </summary>
    public int TotalPages { get; private set; }

    /// <summary>
    /// TRUE if the current page has a previous page,
    /// FALSE otherwise
    /// </summary>
    public bool HasPreviousPase
    {
        get
        {
            return (PageIndex > 0);
        }
    }

    /// <summary>
    /// TRUE if the current page has a next page, FALSE otherwise.
    /// </summary>
    public bool HasNextPage
    {
        get
        {
            return ((PageIndex + 1) < TotalPages);
        }
    }

    /// <summary>
    /// Sorting Column name (or null if none set)
    /// </summary>
    public string? SortColumn { get; set; }

    /// <summary>
    /// Sorting Order ("ASC", "DESC" or null if none set)
    /// </summary>
    public string? SortOrder { get; set; }
    #endregion
}