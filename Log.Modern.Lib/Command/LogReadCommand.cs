using CLIHelper;
using CRUDCommandHelper;
using DataToTable;
using Log.Data;

namespace Log.Modern.Lib;

public class LogReadCommand
    : ReadCommand<ILogUnitOfWork, LogModel, LogArgFilter>
{
    private readonly IFilterFactory<LogModel, LogArgFilter> filterFactory;

    public LogReadCommand(
        ILogUnitOfWork unitOfWork
        , IOutput output
        , IDataToText<LogModel> textProvider
        , IFilterFactory<LogModel, LogArgFilter> filterFactory)
            : base(unitOfWork, output, textProvider)
    {
        this.filterFactory = filterFactory;
    }

    protected override List<LogModel> Get(LogArgFilter model)
    {
        return UnitOfWork.Log.GetLog(
            filterFactory.GetFilter(model)).ToList();
    }
}