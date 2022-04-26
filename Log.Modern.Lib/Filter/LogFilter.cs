using System.Linq.Expressions;
using Log.Data;

namespace Log.Modern.Lib;

#nullable enable
public class LogFilter 
    : IFilterFactory<Data.LogModel, LogArgFilter>
{
    private LogArgFilter? filter;
    private DateTime dateFilter;

    public Expression<Func<Data.LogModel, bool>>? GetFilter(
        LogArgFilter f)
    {
        SetFilter(f);
        if(IsTaskFiltered())
            return GetFilterByTask();
        SetStartFilterValue();
        return IsCategoryFiltered() ?
            GetFilterByStartAndCategory()
            : GetFilterByStart();
    }

    private void SetFilter(LogArgFilter f) =>
        filter = f;

    private void SetStartFilterValue()
    {
        ArgumentNullException.ThrowIfNull(filter);
        dateFilter = filter.Start.HasValue ?
            filter.Start.Value.Date 
            : DateTime.Now.Date;
    }

    private bool IsTaskFiltered()
    {
        ArgumentNullException.ThrowIfNull(filter);
        return filter.TaskId.HasValue;
    } 

    private Expression<Func<LogModel, bool>>? GetFilterByTask()
    {
        ArgumentNullException.ThrowIfNull(filter);
        ArgumentNullException.ThrowIfNull(filter.TaskId);
        return l => l.TaskId == filter.TaskId.Value;
    }

    private bool IsCategoryFiltered()
    {
        ArgumentNullException.ThrowIfNull(filter);
        return filter.CategoryId.HasValue;
    }

    private Expression<Func<LogModel, bool>> GetFilterByStartAndCategory()
    {
        ArgumentNullException.ThrowIfNull(filter);
        ArgumentNullException.ThrowIfNull(filter.CategoryId);
        return l => l.Start.HasValue ?
            l.Start.Value.Date.Equals(dateFilter)
                && l.Task.CategoryId == filter.CategoryId.Value 
            : l.Task.CategoryId == filter.CategoryId.Value;
    }

    private Expression<Func<LogModel, bool>> GetFilterByStart()
    {
        return l => l.Start.HasValue ?
            l.Start.Value.Date.Equals(dateFilter)
            : true;
    }    
}