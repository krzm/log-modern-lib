using DIHelper.Unity;
using Log.Data;
using Unity;

namespace Log.Modern.Lib.Unity;

public class DataFilter 
    : UnityDependencySet
{
    public DataFilter(
        IUnityContainer container) 
            : base(container)
    {
    }

    public override void Register()
    {
        Container
            .RegisterSingleton<
                IFilterFactory<LogModel, LogArgFilter>
                , LogFilter>()
            .RegisterSingleton<
                IFilterFactory<Data.Task, TaskArgFilter>
                , TaskFilter>();
    }
}