using CRUDCommandHelper;
using Log.Data;
using Serilog;

namespace Log.Modern.Lib;

public class CategoryDeleteCommand
    : DeleteCommand<ILogUnitOfWork, Data.Category, DeleteArgs>
{
    public CategoryDeleteCommand(
        ILogUnitOfWork unitOfWork
        , ILogger log) 
            : base(unitOfWork, log)
    {
    }

    protected override void DeleteEntity(Category entity)
    {
        UnitOfWork.Category.Delete(entity);
    }

    protected override Data.Category GetById(int id) =>
        UnitOfWork.Category.GetByID(id);
}