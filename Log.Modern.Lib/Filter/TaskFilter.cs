using System.Linq.Expressions;

namespace Log.Modern.Lib;

public class TaskFilter : IFilterFactory<Data.Task, TaskArgFilter>
{
    public Expression<Func<Data.Task, bool>>? GetFilter(TaskArgFilter filter)
    {
        if(filter.CategoryId.HasValue && string.IsNullOrWhiteSpace(filter.Name) == false)
        {
            return task => 
                task.CategoryId == filter.CategoryId.Value 
                && task.Name.Contains(filter.Name);
        }
        if(filter.CategoryId.HasValue)
            return task => task.CategoryId == filter.CategoryId.Value;
        if(string.IsNullOrWhiteSpace(filter.Name) == false)
            return task => 
                task.Name.Contains(filter.Name);
        return default;
    }
}