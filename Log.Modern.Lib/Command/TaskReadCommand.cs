using CLIHelper;
using CRUDCommandHelper;
using DataToTable;
using Log.Data;
using System.Linq.Expressions;

namespace Log.Modern.Lib;

public class TaskReadCommand 
    : ReadCommand<ILogUnitOfWork, Data.Task, TaskArgFilter>
{
    public TaskReadCommand(
        ILogUnitOfWork unitOfWork
        , IOutput output
        , IDataToText<Data.Task> textProvider) 
            : base(unitOfWork, output, textProvider)
    {
    }

    protected override List<Data.Task> Get(TaskArgFilter model)
    {
        Expression<Func<Data.Task, bool>>? filter = model.CategoryId.HasValue ? f => f.CategoryId == model.CategoryId.Value : null;
        var data = UnitOfWork.Task.Get(
            filter
            , orderBy: t => t.OrderBy(p => p.Category.Name)
            , includeProperties: "Category").ToList();
        return data;
    }
}