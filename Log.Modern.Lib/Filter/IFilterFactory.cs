using System.Linq.Expressions;

namespace Log.Modern.Lib;

#nullable enable
public interface IFilterFactory<TEntity, TFilter>
{
    Expression<Func<TEntity, bool>>? GetFilter(TFilter filter);
}