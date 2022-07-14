using AutoMapper;
using CRUDCommandHelper;
using Log.Data;
using Serilog;

namespace Log.Modern.Lib;

public class LogUpdateCommand
    : UpdateCommand<ILogUnitOfWork, LogModel, LogArgUpdateReset, Data.LogUpdate>
{
    public LogUpdateCommand(
        ILogUnitOfWork unitOfWork
        , ILogger log
        , IMapper mapper)
            : base(unitOfWork, log, mapper)
    {
    }

    protected override LogModel GetById(int id) =>
        UnitOfWork.Log.GetByID(id);
}