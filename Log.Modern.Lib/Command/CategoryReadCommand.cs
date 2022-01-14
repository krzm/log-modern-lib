using CLI.Core;
using CLI.Core.Lib;
using DataToTable;
using Log.Data;

namespace Log.Modern.Lib;

public class CategoryReadCommand 
    : ReadCommand<ILogUnitOfWork, Data.Category, CategoryArgFilter>
{
    public CategoryReadCommand(
        ILogUnitOfWork unitOfWork
        , IOutput output
        , IDataToText<Data.Category> textProvider) 
            : base(unitOfWork, output, textProvider)
    {
    }

    protected override List<Data.Category> Get(CategoryArgFilter model) =>
        UnitOfWork.Category.Get().ToList();
}