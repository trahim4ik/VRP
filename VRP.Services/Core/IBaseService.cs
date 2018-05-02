using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using VRP.Core.Interfaces;
using VRP.DAL.Core;

namespace VRP.Services.Core {
    public interface IBaseService<TEntity, TDto> where TEntity : class, IEntity where TDto : class, IDto {

        /// <summary>
        /// Creates the includes.
        /// </summary>
        /// <param name="includes">The includes.</param>
        /// <returns></returns>
        List<Expression<Func<TEntity, object>>> CreateIncludes(params Expression<Func<TEntity, object>>[] includes);

        /// <summary>
        /// Creates the order bys (sort build).
        /// </summary>
        /// <param name="orderBys">The order bys.</param>
        /// <returns></returns>
        List<IOrderBy<TEntity>> CreateOrderBys(params IOrderBy<TEntity>[] orderBys);

        /// <summary>
        /// Gets the single item and map to Dto.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <param name="includes">The includes.</param>
        /// <param name="orderBys">The order bys.</param>
        /// <returns></returns>
        TDto GetSingle(Expression<Func<TEntity, bool>> predicate, IEnumerable<Expression<Func<TEntity, object>>> includes = null, IEnumerable<IOrderBy<TEntity>> orderBys = null);

        /// <summary>
        /// Gets the single item without tracking and map to Dto.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <param name="includes">The includes.</param>
        /// <param name="orderBys">The order bys.</param>
        /// <returns></returns>
        TDto GetSingleNoTracking(Expression<Func<TEntity, bool>> predicate, IEnumerable<Expression<Func<TEntity, object>>> includes = null, IEnumerable<IOrderBy<TEntity>> orderBys = null);

        /// <summary>
        /// Gets the single.
        /// </summary>
        /// <typeparam name="TRequestedType">The type of the requested type.</typeparam>
        /// <param name="predicate">The predicate.</param>
        /// <param name="includes">The includes.</param>
        /// <param name="orderBys">The order bys.</param>
        /// <param name="select">The select.</param>
        /// <returns></returns>
        TRequestedType GetSingle<TRequestedType>(Expression<Func<TEntity, bool>> predicate, IEnumerable<Expression<Func<TEntity, object>>> includes = null, IEnumerable<IOrderBy<TEntity>> orderBys = null, Expression<Func<TEntity, TRequestedType>> select = null);

        /// <summary>
        /// Gets the single without tracking.
        /// </summary>
        /// <typeparam name="TRequestedType">The type of the requested type.</typeparam>
        /// <param name="predicate">The predicate.</param>
        /// <param name="includes">The includes.</param>
        /// <param name="orderBys">The order bys.</param>
        /// <param name="select">The select.</param>
        /// <returns></returns>
        TRequestedType GetSingleNoTracking<TRequestedType>(Expression<Func<TEntity, bool>> predicate, IEnumerable<Expression<Func<TEntity, object>>> includes = null, IEnumerable<IOrderBy<TEntity>> orderBys = null, Expression<Func<TEntity, TRequestedType>> select = null);

        /// <summary>
        /// Gets the list of items and map to list of Dto.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <param name="includes">The includes.</param>
        /// <param name="orderBys">The order bys.</param>
        /// <returns></returns>
        List<TDto> GetList(Expression<Func<TEntity, bool>> predicate, IEnumerable<Expression<Func<TEntity, object>>> includes = null, IEnumerable<IOrderBy<TEntity>> orderBys = null, int? skip = null, int? take = null);

        /// <summary>
        /// Gets the list of items without tracking and map to list of Dto.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <param name="includes">The includes.</param>
        /// <param name="orderBys">The order bys.</param>
        /// <returns></returns>
        List<TDto> GetListNoTracking(Expression<Func<TEntity, bool>> predicate, IEnumerable<Expression<Func<TEntity, object>>> includes = null, IEnumerable<IOrderBy<TEntity>> orderBys = null, int? skip = null, int? take = null);

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <typeparam name="TRequestedType">The type of the requested type.</typeparam>
        /// <param name="predicate">The predicate.</param>
        /// <param name="includes">The includes.</param>
        /// <param name="orderBys">The order bys.</param>
        /// <param name="select">The select.</param>
        /// <returns></returns>
        List<TRequestedType> GetList<TRequestedType>(Expression<Func<TEntity, bool>> predicate, IEnumerable<Expression<Func<TEntity, object>>> includes = null, IEnumerable<IOrderBy<TEntity>> orderBys = null, Expression<Func<TEntity, TRequestedType>> select = null, int? skip = null, int? take = null);

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <typeparam name="TRequestedType">The type of the requested type.</typeparam>
        /// <param name="predicate">The predicate.</param>
        /// <param name="includes">The includes.</param>
        /// <param name="orderBys">The order bys.</param>
        /// <param name="select">The select.</param>
        /// <returns></returns>
        List<TRequestedType> GetListNoTracking<TRequestedType>(Expression<Func<TEntity, bool>> predicate, IEnumerable<Expression<Func<TEntity, object>>> includes = null, IEnumerable<IOrderBy<TEntity>> orderBys = null, Expression<Func<TEntity, TRequestedType>> select = null, int? skip = null, int? take = null);

        /// <summary>
        /// Gets the group list.
        /// </summary>
        /// <typeparam name="TRequestedType">The type of the requested type.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <param name="predicate">The predicate.</param>
        /// <param name="keySelector">The key selector.</param>
        /// <param name="select">The select.</param>
        /// <param name="includes">The includes.</param>
        /// <returns></returns>
        List<TRequestedType> GetGroupList<TRequestedType, TKey>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TKey>> keySelector, Expression<Func<IGrouping<TKey, TEntity>, TRequestedType>> @select, IEnumerable<Expression<Func<TEntity, object>>> includes = null);

        /// <summary>
        /// Creates the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        TDto Create(TDto model);

        /// <summary>
        /// Creates the specified models.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns></returns>
        List<TDto> Create(List<TDto> models);

        /// <summary>
        /// Create a lot of count records to use Bulk
        /// </summary>
        /// <param name="models"></param>
        void CreateBulk(List<TDto> models);

        /// <summary>
        /// Updates the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        TDto Update(TDto model);

        /// <summary>
        /// Updates the specified models.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns></returns>
        List<TDto> Update(List<TDto> models);

        /// <summary>
        /// Updates the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <param name="includes">The includes.</param>
        /// <param name="action">The action.</param>
        /// <returns></returns>
        List<TDto> Update(Expression<Func<TEntity, bool>> predicate, IEnumerable<Expression<Func<TEntity, object>>> includes = null, Action<TEntity> action = null);

        /// <summary>
        /// Deletes by specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        int Delete(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Counts by specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <param name="includes">The includes.</param>
        /// <returns></returns>
        int Count(Expression<Func<TEntity, bool>> predicate, IEnumerable<Expression<Func<TEntity, object>>> includes = null);
    }
}
