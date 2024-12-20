using Lb_10.Entity;

namespace Lb_10.Builder;

public abstract class SqlBuilder
{
    protected Query _query;

    public Query Build()
    {
        return _query;
    }

    public abstract SqlBuilder Select<T>();
    public abstract SqlBuilder OrderBy(string orderByColumnName);
    public abstract SqlBuilder Take(int count);
}