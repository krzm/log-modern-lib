using System.Linq.Expressions;
using System.Reflection;

namespace Log.Modern.Lib;

public class TaskFilter : IFilterFactory<Data.Task, TaskArgFilter>
{
    public Expression<Func<Data.Task, bool>>? GetFilter(TaskArgFilter filter)
    {
        var containesEx = GetStringContainsExpression<Data.Task>("Name", filter.Name);
        var containsFilter = containesEx.Compile();
        if(filter.CategoryId.HasValue && string.IsNullOrWhiteSpace(filter.Name) == false)
        {
            return task => 
                task.CategoryId == filter.CategoryId.Value 
                || containsFilter.Invoke(task);
        }
        if(filter.CategoryId.HasValue)
            return task => task.CategoryId == filter.CategoryId.Value;
        if(string.IsNullOrWhiteSpace(filter.Name) == false)
            return task => 
                containsFilter.Invoke(task);
        return default;
    }

    static Expression<Func<T, bool>> GetStringContainsExpression<T>
    (string propertyName, string propertyValue)
    {
        var parameterExp = Expression.Parameter(typeof(T), "type");
        var propertyExp = Expression.Property(parameterExp, propertyName);
        MethodInfo method = typeof(string).GetMethod("Contains", new[] { typeof(string) });
        var someValue = Expression.Constant(propertyValue, typeof(string));
        var containsMethodExp = Expression.Call(propertyExp, method, someValue);

        return Expression.Lambda<Func<T, bool>>(containsMethodExp, parameterExp);
    }
}