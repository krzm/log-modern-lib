using AutoMapper;
using CLI.Core;
using CLI.Core.Lib;
using Log.Data;

namespace Log.Modern.Lib;

public class TaskInsertCommand
    : InsertCommand<ILogUnitOfWork, Data.Task, TaskArg>
{
    public TaskInsertCommand(
        ILogUnitOfWork unitOfWork
        , IOutput output
        , IMapper mapper)
            : base(unitOfWork, output, mapper)
    {
    }

    protected override void InsertEntity(Data.Task entity) =>
        UnitOfWork.Task.Insert(entity);
}