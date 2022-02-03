using AutoMapper;
using CLIHelper;
using CRUDCommandHelper;
using Log.Data;

namespace Log.Modern.Lib;

public class TaskUpdateCommand
    : UpdateCommand<ILogUnitOfWork, Data.Task, TaskArgUpdate, Data.TaskUpdate>
{
    public TaskUpdateCommand(
        ILogUnitOfWork unitOfWork
        , IOutput output
        , IMapper mapper)
            : base(unitOfWork, output, mapper)
    {
    }

    protected override Data.Task GetById(int id) =>
        UnitOfWork.Task.GetByID(id);
}