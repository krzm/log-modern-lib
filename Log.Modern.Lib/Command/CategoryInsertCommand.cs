using AutoMapper;
using CLIHelper;
using CRUDCommandHelper;
using Log.Data;

namespace Log.Modern.Lib;

public class CategoryInsertCommand
    : InsertCommand<ILogUnitOfWork, Data.Category, CategoryArg>
{
    public CategoryInsertCommand(
        ILogUnitOfWork unitOfWork
        , IOutput output
        , IMapper mapper) 
            : base(unitOfWork, output, mapper)
    {
    }

    protected override void InsertEntity(Data.Category entity) =>
        UnitOfWork.Category.Insert(entity);
}