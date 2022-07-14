using System.Linq.Expressions;

namespace Log.Modern.Lib;

public class TaskFilter 
    : IFilterFactory<Data.Task, TaskFilterArgs>
{
    public Expression<Func<Data.Task, bool>>? GetFilter(
        TaskFilterArgs filter)
    {
        if(filter.CategoryId.HasValue 
            && string.IsNullOrWhiteSpace(filter.Name) == false)
        {
            return task => 
                task.CategoryId == filter.CategoryId.Value 
                && string.IsNullOrWhiteSpace(task.Name) == false
                && task.Name.Contains(filter.Name);
        }
        if(filter.CategoryId.HasValue)
            return task => task.CategoryId == filter.CategoryId.Value;
        if(string.IsNullOrWhiteSpace(filter.Name) == false)
            return task =>
                string.IsNullOrWhiteSpace(task.Name) == false
                && task.Name.Contains(filter.Name);
        return default;
    }
}