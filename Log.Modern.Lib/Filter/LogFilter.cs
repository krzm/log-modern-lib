using System.Linq.Expressions;

namespace Log.Modern.Lib;

public class LogFilter 
    : IFilterFactory<Data.LogModel, LogArgFilter>
{
    public Expression<Func<Data.LogModel, bool>>? GetFilter(
        LogArgFilter filter)
    {
        var dateFilter = filter.Start.HasValue ? 
            filter.Start.Value.Date : DateTime.Now.Date;

        if(filter.CategoryId.HasValue)
        {
            return l => 
                l.Start.HasValue ? 
                    l.Start.Value.Date.Equals(dateFilter)  
                        && l.Task.CategoryId == filter.CategoryId.Value : 
                    l.Task.CategoryId == filter.CategoryId.Value;
        }
        return l => 
            l.Start.HasValue ? 
                l.Start.Value.Date.Equals(dateFilter) : true;
    }
}