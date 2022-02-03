﻿using AutoMapper;
using CLIHelper;
using CRUDCommandHelper;
using Log.Data;

namespace Log.Modern.Lib;

public class LogInsertCommand
    : InsertCommand<ILogUnitOfWork, LogModel, LogArg>
{
    public LogInsertCommand(
        ILogUnitOfWork unitOfWork
        , IOutput output
        , IMapper mapper)
            : base(unitOfWork, output, mapper)
    {
    }

    protected override void InsertEntity(LogModel entity) =>
        UnitOfWork.Log.Insert(entity);
}