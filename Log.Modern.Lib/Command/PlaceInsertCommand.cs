using AutoMapper;
using CLIHelper;
using CRUDCommandHelper;
using Log.Data;

namespace Log.Modern.Lib;

public class PlaceInsertCommand
    : InsertCommand<ILogUnitOfWork, Data.Place, PlaceArg>
{
    public PlaceInsertCommand(
        ILogUnitOfWork unitOfWork
        , IOutput output
        , IMapper mapper)
            : base(unitOfWork, output, mapper)
    {
    }

    protected override void InsertEntity(Data.Place entity) =>
        UnitOfWork.Place.Insert(entity);
}