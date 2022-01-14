using AutoMapper;
using CLI.Core;
using CLI.Core.Lib;
using Log.Data;

namespace Log.Modern.Lib;

public class CategoryUpdateCommand
    : UpdateCommand<ILogUnitOfWork, Data.Category, CategoryArgUpdate, Data.CategoryUpdate>
{
    public CategoryUpdateCommand(
        ILogUnitOfWork unitOfWork
        , IOutput output
        , IMapper mapper) 
            : base(unitOfWork, output, mapper)
    {
    }

    protected override Data.Category GetById(int id) =>
        UnitOfWork.Category.GetByID(id);
}