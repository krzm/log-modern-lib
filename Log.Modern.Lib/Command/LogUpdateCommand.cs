using AutoMapper;
using CLIHelper;
using CRUDCommandHelper;
using Log.Data;

namespace Log.Modern.Lib;

public class LogUpdateCommand
    : UpdateCommand<ILogUnitOfWork, LogModel, LogArgUpdateReset, Data.LogUpdate>
{
    public LogUpdateCommand(
        ILogUnitOfWork unitOfWork
        , IOutput output
        , IMapper mapper)
            : base(unitOfWork, output, mapper)
    {
    }

    protected override LogModel GetById(int id) =>
        UnitOfWork.Log.GetByID(id);
}