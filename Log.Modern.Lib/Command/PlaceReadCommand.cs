using CLI.Core;
using CLI.Core.Lib;
using DataToTable;
using Log.Data;

namespace Log.Modern.Lib;

public class PlaceReadCommand
    : ReadCommand<ILogUnitOfWork, Data.Place, PlaceArgFilter>
{
    public PlaceReadCommand(
        ILogUnitOfWork unitOfWork
        , IOutput output
        , IDataToText<Data.Place> textProvider) 
            : base(unitOfWork, output, textProvider)
    {
    }

    protected override List<Data.Place> Get(PlaceArgFilter model) =>
        UnitOfWork.Place.Get().ToList();
}