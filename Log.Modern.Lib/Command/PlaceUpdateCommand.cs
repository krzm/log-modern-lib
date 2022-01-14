using AutoMapper;
using CLI.Core;
using CLI.Core.Lib;
using Log.Data;

namespace Log.Modern.Lib;

public class PlaceUpdateCommand
    : UpdateCommand<ILogUnitOfWork, Data.Place, PlaceArgUpdate, Data.PlaceUpdate>
{
    public PlaceUpdateCommand(
        ILogUnitOfWork unitOfWork
        , IOutput output
        , IMapper mapper)
            : base(unitOfWork, output, mapper)
    {
    }

    protected override Data.Place GetById(int id) =>
        UnitOfWork.Place.GetByID(id);
}