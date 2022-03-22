using CLIHelper;
using CRUDCommandHelper;
using DataToTable;
using Log.Data;
using Serilog;

namespace Log.Modern.Lib;

public class LogReadCommand
    : ReadCommand<ILogUnitOfWork, LogModel, LogArgFilter>
{
    private readonly IFilterFactory<LogModel, LogArgFilter> filterFactory;

    public LogReadCommand(
        ILogUnitOfWork unitOfWork
        , IOutput output
        , ILogger log
        , IDataToText<LogModel> textProvider
        , IFilterFactory<LogModel, LogArgFilter> filterFactory)
            : base(unitOfWork, output, log, textProvider)
    {
        this.filterFactory = filterFactory;
    }

    protected override List<LogModel> Get(LogArgFilter model)
    {
        return UnitOfWork.Log.GetLog(
            filterFactory.GetFilter(model)).ToList();
    }
}