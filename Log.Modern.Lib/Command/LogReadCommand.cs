using CLIHelper;
using CRUDCommandHelper;
using DataToTable;
using Log.Data;

namespace Log.Modern.Lib;

public class LogReadCommand
    : ReadCommand<ILogUnitOfWork, LogModel, LogArgFilter>
{
    public LogReadCommand(
        ILogUnitOfWork unitOfWork
        , IOutput output
        , IDataToText<LogModel> textProvider)
            : base(unitOfWork, output, textProvider)
    {
    }

    protected override List<LogModel> Get(LogArgFilter model)
    {
        return UnitOfWork.Log.GetFromTodayOrDateOrBefore(model.Start).ToList();
    }
}