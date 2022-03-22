using CLIHelper;
using CRUDCommandHelper;
using DataToTable;
using Log.Data;
using Serilog;

namespace Log.Modern.Lib;

public class TaskReadCommand 
    : ReadCommand<ILogUnitOfWork, Data.Task, TaskArgFilter>
{
    private readonly IFilterFactory<Data.Task, TaskArgFilter> filterFactory;

    public TaskReadCommand(
        ILogUnitOfWork unitOfWork
        , IOutput output
        , ILogger log
        , IDataToText<Data.Task> textProvider
        , IFilterFactory<Data.Task, TaskArgFilter> filterFactory) 
            : base(unitOfWork, output, log, textProvider)
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
}