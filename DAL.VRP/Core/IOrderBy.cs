using System.Linq;

namespace VRP.DAL.Core {
    public interface IOrderBy<TEntity> where TEntity : class {
        IOrderedQueryable<TEntity> Apply(IQueryable<TEntity> query);
        IOrderedQueryable<TEntity> Apply(IOrderedQueryable<TEntity> query);
    }
}
