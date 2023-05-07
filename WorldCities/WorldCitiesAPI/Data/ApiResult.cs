using Microsoft.EntityFrameworkCore;
namespace WorldCitiesAPI.Data;

public class ApiResult<T>
{
    /// <summary>
    /// Private constructor called by the CreateAsync
    /// </summary>
    private ApiResult(List<T> data, int count, int pageIndex, int pageSize)
    {
        //Data = data;
        //PageIndex = pageIndex;
        //PageSize = pageSize;
        //TotalCount = count;
        //TotalPages = (int)Math.Ceiling(count / (double)pageSize);
    }

    //#region Methods

}
