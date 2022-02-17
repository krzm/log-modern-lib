using CLIHelper;
using CRUDCommandHelper;
using DataToTable;
using Log.Data;

namespace Log.Modern.Lib;

public class TaskReadCommand 
    : ReadCommand<ILogUnitOfWork, Data.Task, TaskArgFilter>
{
    private readonly IFilterFactory<Data.Task, TaskArgFilter> filterFactory;

    public TaskReadCommand(
        ILogUnitOfWork unitOfWork
        , IOutput output
        , IDataToText<Data.Task> textProvider
        , IFilterFactory<Data.Task, TaskArgFilter> filterFactory) 
            : base(unitOfWork, output, textProvider)
    {
        this.filterFactory = filterFactory;
    }

    protected override List<Data.Task> Get(TaskArgFilter model)
    {
        return UnitOfWork.Task.Get(
            filterFactory.GetFilter(model)
            , orderBy: t => t.OrderBy(p => p.Category.Name)
            , includeProperties: "Category").ToList();
    }

    // private static Expression<Func<Data.Task, bool>>? GetFilter(TaskArgFilter filter)
    // {
    //     if(filter.CategoryId.HasValue && string.IsNullOrWhiteSpace(filter.Name) == false)
    //     {
    //         return task => task.CategoryId == filter.CategoryId.Value && 
    //     }
    //     return filter.CategoryId.HasValue ? f => f.CategoryId == filter.CategoryId.Value : null;
    // }
}