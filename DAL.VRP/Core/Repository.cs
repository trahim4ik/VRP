using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using VRP.Core.Interfaces;

namespace VRP.DAL.Core {
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity {

        #region Includes

        /// <inheritdoc cref="IRepository{TEntity}.CreateIncludes"/>
        public List<Expression<Func<TEntity, object>>> CreateIncludes(params Expression<Func<TEntity, object>>[] includes)
            => includes?.ToList();

        #endregion

        #region OrderBy

        /// <inheritdoc cref="IRepository{TEntity}.CreateOrderBys"/>
        public List<IOrderBy<TEntity>> CreateOrderBys(params IOrderBy<TEntity>[] orderBys) => orderBys?.ToList();

        #endregion

        #region Get

        /// <inheritdoc cref="IRepository{TEntity}.GetSingle" /> 
        public TEntity GetSingle(
            Expression<Func<TEntity, bool>> predicate,
            IEnumerable<Expression<Func<TEntity, object>>> includes = null,
            IEnumerable<IOrderBy<TEntity>> orderBys = null
        ) {
            return Query(predicate, includes, orderBys).FirstOrDefault();
        }

        /// <inheritdoc cref="IRepository{TEntity}.GetSingleNoTracking" /> 
        public abstract TEntity GetSingleNoTracking(Expression<Func<TEntity, bool>> predicate,
            IEnumerable<Expression<Func<TEntity, object>>> includes = null,
            IEnumerable<IOrderBy<TEntity>> orderBys = null);

        /// <inheritdoc cref="IRepository{TEntity}.GetSingle" /> 
        public TRequestedType GetSingle<TRequestedType>(
            Expression<Func<TEntity, bool>> predicate,
            IEnumerable<Expression<Func<TEntity, object>>> includes = null,
            IEnumerable<IOrderBy<TEntity>> orderBys = null,
            Expression<Func<TEntity, TRequestedType>> @select = null
        ) {
            return SelectRequestedTypes(Query(predicate, includes, orderBys), select).FirstOrDefault();
        }

        /// <inheritdoc cref="IRepository{TEntity}.GetSingleNoTracking" /> 
        public abstract TRequestedType GetSingleNoTracking<TRequestedType>(Expression<Func<TEntity, bool>> predicate,
            IEnumerable<Expression<Func<TEntity, object>>> includes = null,
            IEnumerable<IOrderBy<TEntity>> orderBys = null, Expression<Func<TEntity, TRequestedType>> @select = null);

        /// <inheritdoc cref="IRepository{TEntity}.GetList"/>
        public List<TEntity> GetList(
            Expression<Func<TEntity, bool>> predicate,
            IEnumerable<Expression<Func<TEntity, object>>> includes = null,
            IEnumerable<IOrderBy<TEntity>> orderBys = null,
            int? skip = null,
            int? take = null
        ) {
            return Query(predicate, includes, orderBys, skip, take).ToList();
        }

        /// <inheritdoc cref="IRepository{TEntity}.GetListNoTracking"/>
        public abstract List<TEntity> GetListNoTracking(Expression<Func<TEntity, bool>> predicate,
            IEnumerable<Expression<Func<TEntity, object>>> includes = null,
            IEnumerable<IOrderBy<TEntity>> orderBys = null, int? skip = null,
            int? take = null);

        /// <inheritdoc cref="IRepository{TEntity}.GetList"/>
        public List<TRequestedType> GetList<TRequestedType>(
            Expression<Func<TEntity, bool>> predicate,
            IEnumerable<Expression<Func<TEntity, object>>> includes = null,
            IEnumerable<IOrderBy<TEntity>> orderBys = null,
            Expression<Func<TEntity, TRequestedType>> @select = null,
            int? skip = null,
            int? take = null
        ) {
            return SelectRequestedTypes(Query(predicate, includes, orderBys, skip, take), select).ToList();
        }

        /// <inheritdoc cref="IRepository{TEntity}.GetListNoTracking"/>
        public abstract List<TRequestedType> GetListNoTracking<TRequestedType>(Expression<Func<TEntity, bool>> predicate,
            IEnumerable<Expression<Func<TEntity, object>>> includes = null,
            IEnumerable<IOrderBy<TEntity>> orderBys = null,
            Expression<Func<TEntity, TRequestedType>> @select = null, int? skip = null, int? take = null);

        /// <inheritdoc cref="IRepository{TEntity}.GetGroupList{TRequestedType, TKey}"/>
        public List<TRequestedType> GetGroupList<TRequestedType, TKey>(
            Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, TKey>> keySelector,
            Expression<Func<IGrouping<TKey, TEntity>, TRequestedType>> @select,
            IEnumerable<Expression<Func<TEntity, object>>> includes = null
        ) {
            var groupQuery = Query(predicate, includes, null).GroupBy(keySelector);
            return SelectRequestedTypes(groupQuery, select).ToList();
        }

        #endregion

        #region Create

        /// <inheritdoc cref="IRepository{TEntity}.Create(TEntity)"/>
        public TEntity Create(TEntity model) {
            return Create(new List<TEntity> { model }).FirstOrDefault();
        }

        /// <inheritdoc cref="IRepository{TEntity}.Create(List{TEntity})"/>
        public List<TEntity> Create(List<TEntity> models) {
            if (models == null) throw new ArgumentNullException(nameof(models), $"Repository<{typeof(TEntity).FullName}>.Create");
            try {
                if (!IsInTransaction()) BeginTransaction();
                var result = CreateNoTransaction(models);
                if (IsTransactionOwner()) CommitTransaction();
                return result;
            } catch {
                if (IsTransactionOwner()) RollbackTransaction();
                throw;
            }
        }

        /// <inheritdoc cref="IRepository{TEntity}.CreateNoTransaction(TEntity)"/>
        public TEntity CreateNoTransaction(TEntity model) {
            return CreateNoTransaction(new List<TEntity> { model }).FirstOrDefault();
        }

        /// <inheritdoc cref="IRepository{TEntity}.CreateNoTransaction(List{TEntity})"/>
        public abstract List<TEntity> CreateNoTransaction(List<TEntity> models);

        #endregion

        #region Update

        /// <inheritdoc cref="IRepository{TEntity}.Update(TEntity)"/>
        public TEntity Update(TEntity model) => Update(new List<TEntity> { model }).FirstOrDefault();

        /// <inheritdoc cref="IRepository{TEntity}.Update(List{TEntity})"/>
        public List<TEntity> Update(List<TEntity> models) {
            if (models == null) throw new ArgumentNullException(nameof(models), $"Repository<{typeof(TEntity).FullName}>.Update ");
            try {
                if (!IsInTransaction()) BeginTransaction();
                var result = UpdateNoTransaction(models);
                if (IsTransactionOwner()) CommitTransaction();
                return result;
            } catch {
                if (IsTransactionOwner()) RollbackTransaction();
                throw;
            }
        }

        /// <inheritdoc cref="IRepository{TEntity}.Update(Expression{Func{TEntity, bool}}, IEnumerable{Expression{Func{TEntity, object}}}, Action{TEntity})"/>
        public List<TEntity> Update(
            Expression<Func<TEntity, bool>> predicate,
            IEnumerable<Expression<Func<TEntity, object>>> includes = null,
            Action<TEntity> action = null) {
            if (predicate == null) throw new ArgumentNullException(nameof(predicate), $"Repository<{typeof(TEntity).FullName}>.Update ");
            try {
                if (!IsInTransaction()) BeginTransaction();
                var result = UpdateNoTransaction(predicate, includes, action);
                if (IsTransactionOwner()) CommitTransaction();
                return result;
            } catch {
                if (IsTransactionOwner()) RollbackTransaction();
                throw;
            }
        }

        /// <inheritdoc cref="IRepository{TEntity}.UpdateNoTransaction(TEntity)"/>
        public TEntity UpdateNoTransaction(TEntity model) {
            return UpdateNoTransaction(new List<TEntity> { model }).FirstOrDefault();
        }

        /// <inheritdoc cref="IRepository{TEntity}.UpdateNoTransaction(List{TEntity})"/>
        public abstract List<TEntity> UpdateNoTransaction(List<TEntity> models);

        /// <inheritdoc cref="IRepository{TEntity}.UpdateNoTransaction(Expression{Func{TEntity, bool}}, IEnumerable{Expression{Func{TEntity, object}}}, Action{TEntity})"/>
        public abstract List<TEntity> UpdateNoTransaction(
            Expression<Func<TEntity, bool>> predicate,
            IEnumerable<Expression<Func<TEntity, object>>> includes = null,
            Action<TEntity> action = null
        );
        #endregion

        #region Delete

        /// <inheritdoc cref="IRepository{TEntity}.Delete"/>
        public int Delete(Expression<Func<TEntity, bool>> predicate) {
            var count = 0;
            try {
                if (!IsInTransaction()) BeginTransaction();
                count = DeleteNoTransaction(predicate);
                if (IsTransactionOwner()) CommitTransaction();
            } catch {
                if (IsTransactionOwner()) RollbackTransaction();
                throw;
            }
            return count;
        }

        /// <inheritdoc cref="IRepository{TEntity}.DeleteNoTransaction"/>
        public abstract int DeleteNoTransaction(Expression<Func<TEntity, bool>> predicate);

        #endregion

        #region Count

        /// <inheritdoc cref="IRepository{TEntity}.Count"/>
        public int Count(Expression<Func<TEntity, bool>> predicate, IEnumerable<Expression<Func<TEntity, object>>> includes = null) {
            return Query(predicate, includes).Count();
        }

        #endregion

        #region Query

        /// <summary>
        /// Query builder
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="includeList"></param>
        /// <param name="orderBys"></param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        protected abstract IQueryable<TEntity> Query(
            Expression<Func<TEntity, bool>> predicate = null,
            IEnumerable<Expression<Func<TEntity, object>>> includeList = null,
            IEnumerable<IOrderBy<TEntity>> orderBys = null,
            int? skip = null,
            int? take = null
        );

        #endregion

        #region Transaction

        /// <inheritdoc cref="IRepository{TEntity}.IsInTransaction"/>
        public abstract bool IsInTransaction();

        /// <inheritdoc cref="IRepository{TEntity}.IsTransactionOwner"/>
        public abstract bool IsTransactionOwner();

        /// <inheritdoc cref="IRepository{TEntity}.BeginTransaction"/>
        public abstract void BeginTransaction();

        /// <inheritdoc cref="IRepository{TEntity}.CommitTransaction"/>
        public abstract void CommitTransaction();

        /// <inheritdoc cref="IRepository{TEntity}.RollbackTransaction"/>
        public abstract void RollbackTransaction();

        #endregion

        #region Helpers

        /// <summary>
        /// Converting to TRequestedType
        /// </summary>
        /// <typeparam name="TRequestedType"></typeparam>
        /// <param name="query"></param>
        /// <param name="select"></param>
        /// <returns></returns>
        protected IQueryable<TRequestedType> SelectRequestedTypes<TRequestedType>(
            IQueryable<TEntity> query,
            Expression<Func<TEntity, TRequestedType>> select
        ) {
            if (select == null) {
                throw new ArgumentNullException(nameof(select));
            }
            return query.Select(select);
        }

        /// <summary>
        /// Converting to TRequestedType
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TRequestedType"></typeparam>
        /// <param name="query"></param>
        /// <param name="select"></param>
        /// <returns></returns>
        protected IQueryable<TRequestedType> SelectRequestedTypes<TKey, TRequestedType>(
            IQueryable<IGrouping<TKey, TEntity>> query,
            Expression<Func<IGrouping<TKey, TEntity>, TRequestedType>> select
        ) {
            if (select == null) {
                throw new ArgumentNullException(nameof(select));
            }
            return query.Select(select);
        }

        #endregion
    }
}
