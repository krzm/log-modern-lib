using AutoMapper;
using Log.Data;
using Unity;
using Task = Log.Data.Task;

namespace Log.Modern.Lib.Unity;

public class AppMappings 
    : ModelHelper.AppMappings
{
    public AppMappings(
        IUnityContainer container)
        : base(container)
    {
    }

    protected override MapperConfiguration CreateMap() => 
        new (
        c =>
        {
            c.CreateMap<PlaceArg, Place>();
            c.CreateMap<CategoryInsertArgs, Category>();
            c.CreateMap<TaskArg, Task>();
            c.CreateMap<LogInsertArgs, LogModel>();

            c.CreateMap<PlaceArgUpdate, PlaceUpdate>();
            c.CreateMap<CategoryUpdateArgs, CategoryUpdate>();
            c.CreateMap<TaskArgUpdate, TaskUpdate>();
            c.CreateMap<LogArgUpdateReset, LogUpdate>();
        });
}