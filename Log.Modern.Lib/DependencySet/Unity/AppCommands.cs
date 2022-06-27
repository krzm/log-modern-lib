using CRUDCommandHelper;
using DIHelper.Unity;
using Unity;

namespace Log.Modern.Lib.Unity;

public class AppCommands 
    : UnityDependencySet
{
    public AppCommands(
        IUnityContainer container) 
        : base(container)
    {
    }

    public override void Register()
    {
        RegisterReadCommands();
        RegisterInsertCommands();
        RegisterUpdateCommands();
        RegisterDeleteCommands();
    }

    private void RegisterReadCommands()
    {
        Container
            .RegisterSingleton<IReadCommand<PlaceArgFilter>, PlaceReadCommand>()
            .RegisterSingleton<IReadCommand<CategoryArgFilter>, CategoryReadCommand>()
            .RegisterSingleton<IReadCommand<TaskArgFilter>, TaskReadCommand>()
            .RegisterSingleton<IReadCommand<LogFilterArgs>, LogReadCommand>();
    }

    private void RegisterInsertCommands()
    {
        Container
            .RegisterSingleton<IInsertCommand<PlaceArg>, PlaceInsertCommand>()
            .RegisterSingleton<IInsertCommand<CategoryArg>, CategoryInsertCommand>()
            .RegisterSingleton<IInsertCommand<Lib.TaskArg>, TaskInsertCommand>()
            .RegisterSingleton<IInsertCommand<Lib.LogArg>, LogInsertCommand>();
    }

    private void RegisterUpdateCommands()
    {
        Container
            .RegisterSingleton<IUpdateCommand<PlaceArgUpdate>, PlaceUpdateCommand>()
            .RegisterSingleton<IUpdateCommand<CategoryArgUpdate>, CategoryUpdateCommand>()
            .RegisterSingleton<IUpdateCommand<TaskArgUpdate>, TaskUpdateCommand>()
            .RegisterSingleton<IUpdateCommand<LogArgUpdateReset>, LogUpdateCommand>();
    }

    private void RegisterDeleteCommands()
    {
        Container
            .RegisterSingleton<IDeleteCommand<DeleteArgs>, CategoryDeleteCommand>();
    }
}