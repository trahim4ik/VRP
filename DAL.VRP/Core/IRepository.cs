using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using VRP.Core.Interfaces;

namespace VRP.DAL.Core {
    public interface IRepository<TEntity> where TEntity : class, IEntity {

        /// <summary>
        /// Create includes for query
        /// </summary>
        /// <example>
        /// 1. one->to-one
        /// CreateIncludes(x => x.IncludedProperty)
        /// 2. one->to-many-to>-one
        /// CreateIncludes(x => x.IncludedProperty.Select(y=>y.InnerProperty))
        /// </example>
        /// <param name="includes"></param>
        /// <returns></returns>
        List<Expression<Func<TEntity, object>>> CreateIncludes(params Expression<Func<TEntity, object>>[] includes);

        /// <summary>
        /// Create sorting for query
        /// SAMPLES:
        /// 1. ascending
        /// CreateOrderBys(new OrderBy <TEntity, TypeOfSortField>(x => x.SortField))
        /// 2. descending
        /// OrderByDescending(new OrderBy<TEntity, TypeOfSortField>(x => x.SortField))
        /// </summary>
        /// <param name="orderBys"></param>
        /// <returns></returns>
        List<IOrderBy<TEntity>> CreateOrderBys(params IOrderBy<TEntity>[] orderBys);

        /// <summary>
        /// Get a single record
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="includes"></param>
        /// <param name="orderBys"></param>
        /// <returns></returns>
        TEntity GetSingle(Expression<Func<TEntity, bool>> predicate, IEnumerable<Expression<Func<TEntity, object>>> includes = null, IEnumerable<IOrderBy<TEntity>> orderBys = null);

        /// <summary>
        /// Get a single record without tracking
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="includes"></param>
        /// <param name="orderBys"></param>
        /// <returns></returns>
        TEntity GetSingleNoTracking(Expression<Func<TEntity, bool>> predicate, IEnumerable<Expression<Func<TEntity, object>>> includes = null, IEnumerable<IOrderBy<TEntity>> orderBys = null);

        /// <summary>
        /// Get single record of return type
        /// </summary>
        /// <typeparam name="TRequestedType"></typeparam>
        /// <param name="predicate"></param>
        /// <param name="includes"></param>
        /// <param name="orderBys"></param>
        /// <param name="select"></param>
        /// <returns></returns>
        TRequestedType GetSingle<TRequestedType>(Expression<Func<TEntity, bool>> predicate, IEnumerable<Expression<Func<TEntity, object>>> includes = null, IEnumerable<IOrderBy<TEntity>> orderBys = null, Expression<Func<TEntity, TRequestedType>> select = null);

        /// <summary>
        /// Get a single record of return type without tracking
        /// </summary>
        /// <typeparam name="TRequestedType"></typeparam>
        /// <param name="predicate"></param>
        /// <param name="includes"></param>
        /// <param name="orderBys"></param>
        /// <param name="select"></param>
        /// <returns></returns>
        TRequestedType GetSingleNoTracking<TRequestedType>(Expression<Func<TEntity, bool>> predicate, IEnumerable<Expression<Func<TEntity, object>>> includes = null, IEnumerable<IOrderBy<TEntity>> orderBys = null, Expression<Func<TEntity, TRequestedType>> select = null);

        /// <summary>
        /// Get list of records
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="includes"></param>
        /// <param name="orderBys"></param>
        /// <returns></returns>
        List<TEntity> GetList(Expression<Func<TEntity, bool>> predicate, IEnumerable<Expression<Func<TEntity, object>>> includes = null, IEnumerable<IOrderBy<TEntity>> orderBys = null, int? skip = null, int? take = null);

        /// <summary>
        /// Get list of records without tracking
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="includes"></param>
        /// <param name="orderBys"></param>
        /// <returns></returns>
        List<TEntity> GetListNoTracking(Expression<Func<TEntity, bool>> predicate, IEnumerable<Expression<Func<TEntity, object>>> includes = null, IEnumerable<IOrderBy<TEntity>> orderBys = null, int? skip = null, int? take = null);

        /// <summary>
        /// Get list of records of return type
        /// </summary>
        /// <typeparam name="TRequestedType"></typeparam>
        /// <param name="predicate"></param>
        /// <param name="includes"></param>
        /// <param name="orderBys"></param>
        /// <param name="select"></param>
        /// <returns></returns>
        List<TRequestedType> GetList<TRequestedType>(Expression<Func<TEntity, bool>> predicate, IEnumerable<Expression<Func<TEntity, object>>> includes = null, IEnumerable<IOrderBy<TEntity>> orderBys = null, Expression<Func<TEntity, TRequestedType>> select = null, int? skip = null, int? take = null);

        /// <summary>
        /// Get list of records of return type without tracking
        /// </summary>
        /// <typeparam name="TRequestedType"></typeparam>
        /// <param name="predicate"></param>
        /// <param name="includes"></param>
        /// <param name="orderBys"></param>
        /// <param name="select"></param>
        /// <returns></returns>
        List<TRequestedType> GetListNoTracking<TRequestedType>(Expression<Func<TEntity, bool>> predicate, IEnumerable<Expression<Func<TEntity, object>>> includes = null, IEnumerable<IOrderBy<TEntity>> orderBys = null, Expression<Func<TEntity, TRequestedType>> select = null, int? skip = null, int? take = null);

        /// <summary>
        /// Get grouped list
        /// </summary>
        /// <typeparam name="TRequestedType"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="predicate"></param>
        /// <param name="keySelector"></param>
        /// <param name="select"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        List<TRequestedType> GetGroupList<TRequestedType, TKey>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TKey>> keySelector, Expression<Func<IGrouping<TKey, TEntity>, TRequestedType>> @select, IEnumerable<Expression<Func<TEntity, object>>> includes = null);

        /// <summary>
        /// Create  a new record
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        TEntity Create(TEntity model);

        /// <summary>
        /// Create new item in exising transaction
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        TEntity CreateNoTransaction(TEntity model);

        /// <summary>
        /// Create new records
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        List<TEntity> Create(List<TEntity> models);

        /// <summary>
        /// Create new items in exising transaction
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        List<TEntity> CreateNoTransaction(List<TEntity> models);

        /// <summary>
        /// Update item
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        TEntity Update(TEntity model);

        /// <summary>
        /// Update item in exising transaction
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        TEntity UpdateNoTransaction(TEntity model);

        /// <summary>
        /// Update items
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        List<TEntity> Update(List<TEntity> models);

        /// <summary>
        /// Update items in exising transaction
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        List<TEntity> UpdateNoTransaction(List<TEntity> models);

        /// <summary>
        /// Update items found by peredicate applying action
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="includes"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        List<TEntity> Update(Expression<Func<TEntity, bool>> predicate, IEnumerable<Expression<Func<TEntity, object>>> includes = null, Action<TEntity> action = null);

        /// <summary>
        /// Update items found by peredicate applying action in exising transaction
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="includes"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        List<TEntity> UpdateNoTransaction(Expression<Func<TEntity, bool>> predicate, IEnumerable<Expression<Func<TEntity, object>>> includes = null, Action<TEntity> action = null);

        /// <summary>
        /// Delete items
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        int Delete(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Delete items in exising transaction
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        int DeleteNoTransaction(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Get a count of items
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        int Count(Expression<Func<TEntity, bool>> predicate, IEnumerable<Expression<Func<TEntity, object>>> includes = null);

        /// <summary>
        /// Is transaction started
        /// </summary>
        /// <returns></returns>
        bool IsInTransaction();

        /// <summary>
        /// Is current repository creator of transaction
        /// </summary>
        /// <returns></returns>
        bool IsTransactionOwner();

        /// <summary>
        /// Begin transaction
        /// </summary>
        void BeginTransaction();

        /// <summary>
        /// Commit transaction
        /// </summary>
        void CommitTransaction();

        /// <summary>
        /// Rollback transaction
        /// </summary>
        void RollbackTransaction();
    }
}
