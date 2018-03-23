using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using VRP.Core.Interfaces;

namespace VRP.DAL.Core
{
    public class DbRepository<TEntity> : Repository<TEntity> where TEntity : class, IEntity {

        #region properties

        private readonly ApplicationDbContext _dbContext;
        private IDbContextTransaction _dbTransaction;

        #endregion

        #region Constructor

        public DbRepository(ApplicationDbContext dbContext) {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext), $"DbRepository<{typeof(TEntity).FullName}> Constructor");
            _dbTransaction = null;
        }

        #endregion

        #region Implementation

        /// <inheritdoc cref="IRepository{TEntity}.GetSingleNoTracking"/>
        public override TEntity GetSingleNoTracking(Expression<Func<TEntity, bool>> predicate, IEnumerable<Expression<Func<TEntity, object>>> includes = null, IEnumerable<IOrderBy<TEntity>> orderBys = null) {
            return Query(predicate, includes, orderBys).AsNoTracking().FirstOrDefault();
        }

        /// <inheritdoc cref="IRepository{TRequestedType}.GetSingleNoTracking"/>
        public override TRequestedType GetSingleNoTracking<TRequestedType>(Expression<Func<TEntity, bool>> predicate, IEnumerable<Expression<Func<TEntity, object>>> includes = null,
            IEnumerable<IOrderBy<TEntity>> orderBys = null, Expression<Func<TEntity, TRequestedType>> @select = null) {
            return SelectRequestedTypes(Query(predicate, includes, orderBys).AsNoTracking(), select).FirstOrDefault();
        }

        /// <inheritdoc cref="IRepository{TEntity}.GetListNoTracking"/>
        public override List<TEntity> GetListNoTracking(Expression<Func<TEntity, bool>> predicate, IEnumerable<Expression<Func<TEntity, object>>> includes = null, IEnumerable<IOrderBy<TEntity>> orderBys = null, int? skip = null,
            int? take = null) {
            return Query(predicate, includes, orderBys, skip, take).AsNoTracking().ToList();
        }

        /// <inheritdoc cref="IRepository{TRequestedType}.GetListNoTracking"/>
        public override List<TRequestedType> GetListNoTracking<TRequestedType>(Expression<Func<TEntity, bool>> predicate, IEnumerable<Expression<Func<TEntity, object>>> includes = null, IEnumerable<IOrderBy<TEntity>> orderBys = null,
            Expression<Func<TEntity, TRequestedType>> @select = null, int? skip = null, int? take = null) {
            return SelectRequestedTypes(Query(predicate, includes, orderBys, skip, take).AsNoTracking(), select).ToList();
        }

        /// <inheritdoc cref="IRepository{TEntity}.CreateNoTransaction(List{TEntity})"/>
        public override List<TEntity> CreateNoTransaction(List<TEntity> models) {
            var dbSet = _dbContext.Set<TEntity>();
            dbSet.AddRange(models);
            SaveChanges();
            return models;
        }

        /// <inheritdoc cref="IRepository{TEntity}.UpdateNoTransaction(List{TEntity})"/>
        public override List<TEntity> UpdateNoTransaction(List<TEntity> models) {
            var dbSet = _dbContext.Set<TEntity>();
            foreach (var model in models) {
                dbSet.Attach(model);
                _dbContext.Entry(model).State = EntityState.Modified;
            }
            SaveChanges();
            return models;
        }

        /// <inheritdoc cref="IRepository{TEntity}.UpdateNoTransaction(Expression{Func{TEntity, bool}}, IEnumerable{Expression{Func{TEntity, object}}}, Action{TEntity})"/>
        public override List<TEntity> UpdateNoTransaction(Expression<Func<TEntity, bool>> predicate, IEnumerable<Expression<Func<TEntity, object>>> includes = null, Action<TEntity> action = null) {
            var items = Query(predicate, includes).ToList();
            if (action == null) return items;

            foreach (var entity in items) {
                action(entity);
                _dbContext.Entry(entity).State = EntityState.Modified;
            }

            SaveChanges();

            return items;
        }

        /// <inheritdoc cref="IRepository{TEntity}.DeleteNoTransaction"/>
        public override int DeleteNoTransaction(Expression<Func<TEntity, bool>> predicate) {
            var itemCount = 0;
            var dbSet = _dbContext.Set<TEntity>();
            var items = dbSet.Where(predicate);

            if (!items.Any()) return itemCount;

            dbSet.RemoveRange(items);
            itemCount = items.Count();
            SaveChanges();

            return itemCount;
        }

        /// <inheritdoc cref="Repository{TEntity}.Query"/>
        protected override IQueryable<TEntity> Query(
            Expression<Func<TEntity, bool>> predicate = null,
            IEnumerable<Expression<Func<TEntity, object>>> includeList = null,
            IEnumerable<IOrderBy<TEntity>> orderBys = null,
            int? skip = null,
            int? take = null
        ) {
            return Query(_dbContext, predicate, includeList, orderBys, skip, take);
        }

        /// <inheritdoc cref="IRepository{TEntity}.IsInTransaction"/>
        public override bool IsInTransaction() {
            return _dbContext.Database.CurrentTransaction != null;
        }

        /// <see cref="IRepository{TEntity}.IsTransactionOwner"/>
        public override bool IsTransactionOwner() {
            return _dbTransaction != null;
        }

        /// <inheritdoc cref="IRepository{TEntity}.BeginTransaction"/>
        public override void BeginTransaction() {
            if (!IsInTransaction()) {
                _dbTransaction = _dbContext.Database.BeginTransaction();
            }
        }

        /// <inheritdoc cref="Repository{TEntity}.CommitTransaction"/>
        public override void CommitTransaction() {
            if (_dbTransaction != null) {
                _dbTransaction.Commit();
                _dbTransaction.Dispose();
            }
            _dbTransaction = null;
        }

        /// <inheritdoc cref="IRepository{TEntity}.RollbackTransaction"/>
        public override void RollbackTransaction() {
            if (_dbTransaction != null) {
                _dbTransaction.Rollback();
                _dbTransaction.Dispose();
            }
            _dbTransaction = null;
        }

        #endregion

        #region Helpers

        /// <summary>
        /// Query builder in specified DB context
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="predicate"></param>
        /// <param name="includeList"></param>
        /// <param name="orderBys"></param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        private IQueryable<TEntity> Query(
            ApplicationDbContext dbContext,
            Expression<Func<TEntity, bool>> predicate = null,
            IEnumerable<Expression<Func<TEntity, object>>> includeList = null,
            IEnumerable<IOrderBy<TEntity>> orderBys = null,
            int? skip = null,
            int? take = null
        ) {
            var query = dbContext.Set<TEntity>().AsQueryable();
            if (includeList != null) {
                foreach (var expression in includeList) {
                    if (IncludesBuilder.TryParsePath(expression.Body, out var path) && !string.IsNullOrEmpty(path)) {
                        query = query.Include(path);
                    }
                }
            }

            if (predicate != null) {
                query = query.Where(predicate);
            }

            if (orderBys != null) {
                var ordered = orderBys.Aggregate<IOrderBy<TEntity>, IOrderedQueryable<TEntity>>(null, (current, orderBy) => current == null ? orderBy.Apply(query) : orderBy.Apply(current));
                query = ordered ?? query;
            }

            if (skip.HasValue) {
                query = query.Skip(skip.Value);
            }

            if (take.HasValue) {
                query = query.Take(take.Value);
            }

            return query;
        }

        private void SaveChanges() {
            _dbContext.SaveChanges();
        }

        #endregion
    }
}
