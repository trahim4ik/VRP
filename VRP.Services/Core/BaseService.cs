using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using VRP.Core.Interfaces;
using VRP.DAL.Core;

namespace VRP.Services.Core {
    public abstract class BaseService {

        protected IMapper Mapper;

        protected IServiceProvider ServiceProvider;

        protected BaseService(IServiceProvider serviceProvider) {
            ServiceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider), "BaseService Constructor");
            Mapper = serviceProvider.GetRequiredService<IMapper>();
        }
    }

    public class BaseService<TEntity, TDto> : BaseService,
        IBaseService<TEntity, TDto> where TEntity : class, IEntity where TDto : class, IDto {

        #region Properties

        protected IRepository<TEntity> Repository { get; set; }

        #endregion

        #region Constructor

        public BaseService(IServiceProvider serviceProvider) : base(serviceProvider) {
            Repository = serviceProvider.GetRequiredService<IRepository<TEntity>>();
        }

        #endregion

        #region Helper Actions

        /// <inheritdoc cref="IBaseService{TEntity,TDto}.CreateIncludes"/>
        public List<Expression<Func<TEntity, object>>> CreateIncludes(
            params Expression<Func<TEntity, object>>[] includes) {
            return Repository.CreateIncludes(includes);
        }

        /// <inheritdoc cref="IBaseService{TEntity,TDto}.CreateOrderBys"/>
        public List<IOrderBy<TEntity>> CreateOrderBys(params IOrderBy<TEntity>[] orderBys) {
            return Repository.CreateOrderBys(orderBys);
        }

        #endregion

        #region Get

        /// <inheritdoc cref="IBaseService{TEntity,TDto}.GetSingle"/>
        public virtual TDto GetSingle(
            Expression<Func<TEntity, bool>> predicate,
            IEnumerable<Expression<Func<TEntity, object>>> includes = null,
            IEnumerable<IOrderBy<TEntity>> orderBys = null
        ) {
            return Mapper.Map<TEntity, TDto>(Repository.GetSingle(predicate, includes, orderBys));
        }

        /// <inheritdoc cref="IBaseService{TEntity,TDto}.GetSingleNoTracking"/>
        public TDto GetSingleNoTracking(Expression<Func<TEntity, bool>> predicate,
            IEnumerable<Expression<Func<TEntity, object>>> includes = null,
            IEnumerable<IOrderBy<TEntity>> orderBys = null) {
            return Mapper.Map<TEntity, TDto>(Repository.GetSingleNoTracking(predicate, includes, orderBys));
        }

        /// <inheritdoc cref="IBaseService{TEntity,TDto}.GetSingle"/>
        public virtual TRequestedType GetSingle<TRequestedType>(
            Expression<Func<TEntity, bool>> predicate,
            IEnumerable<Expression<Func<TEntity, object>>> includes = null,
            IEnumerable<IOrderBy<TEntity>> orderBys = null,
            Expression<Func<TEntity, TRequestedType>> @select = null
        ) {
            return Repository.GetSingle(predicate, includes, orderBys, select);
        }

        /// <inheritdoc cref="IBaseService{TEntity,TDto}.GetSingleNoTracking"/>
        public TRequestedType GetSingleNoTracking<TRequestedType>(Expression<Func<TEntity, bool>> predicate,
            IEnumerable<Expression<Func<TEntity, object>>> includes = null,
            IEnumerable<IOrderBy<TEntity>> orderBys = null, Expression<Func<TEntity, TRequestedType>> @select = null) {
            return Repository.GetSingleNoTracking(predicate, includes, orderBys, select);
        }

        /// <inheritdoc cref="IBaseService{TEntity,TDto}.GetList"/>
        public virtual List<TDto> GetList(
            Expression<Func<TEntity, bool>> predicate,
            IEnumerable<Expression<Func<TEntity, object>>> includes = null,
            IEnumerable<IOrderBy<TEntity>> orderBys = null,
            int? skip = null,
            int? take = null
        ) {
            return Repository.GetList(predicate, includes, orderBys, skip, take).Select(Mapper.Map<TEntity, TDto>)
                .ToList();
        }

        /// <inheritdoc cref="IBaseService{TEntity,TDto}.GetListNoTracking"/>
        public List<TDto> GetListNoTracking(
            Expression<Func<TEntity, bool>> predicate,
            IEnumerable<Expression<Func<TEntity, object>>> includes = null,
            IEnumerable<IOrderBy<TEntity>> orderBys = null,
            int? skip = null,
            int? take = null
        ) {
            return Repository.GetListNoTracking(predicate, includes, orderBys, skip, take)
                .Select(Mapper.Map<TEntity, TDto>)
                .ToList();
        }

        /// <inheritdoc cref="IBaseService{TEntity,TDto}.GetList"/>
        public virtual List<TRequestedType> GetList<TRequestedType>(
            Expression<Func<TEntity, bool>> predicate,
            IEnumerable<Expression<Func<TEntity, object>>> includes = null,
            IEnumerable<IOrderBy<TEntity>> orderBys = null,
            Expression<Func<TEntity, TRequestedType>> @select = null,
            int? skip = null,
            int? take = null
        ) {
            return Repository.GetList(predicate, includes, orderBys, select, skip, take);
        }

        /// <inheritdoc cref="IBaseService{TEntity,TDto}.GetListNoTracking"/>
        public List<TRequestedType> GetListNoTracking<TRequestedType>(
            Expression<Func<TEntity, bool>> predicate,
            IEnumerable<Expression<Func<TEntity, object>>> includes = null,
            IEnumerable<IOrderBy<TEntity>> orderBys = null,
            Expression<Func<TEntity, TRequestedType>> @select = null,
            int? skip = null,
            int? take = null
        ) {
            return Repository.GetListNoTracking(predicate, includes, orderBys, select, skip, take);
        }

        /// <inheritdoc cref="IBaseService{TEntity,TDto}.GetGroupList{TRequestedType, TKey}(Expression{Func{TEntity, bool}}, Expression{Func{TEntity, TKey}}, Expression{Func{IGrouping{TKey,TElement}, TRequestedType}} ,IEnumerable{Expression{Func{TEntity, object}}})"/>
        public virtual List<TRequestedType> GetGroupList<TRequestedType, TKey>(
            Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, TKey>> keySelector,
            Expression<Func<IGrouping<TKey, TEntity>, TRequestedType>> @select,
            IEnumerable<Expression<Func<TEntity, object>>> includes = null
        ) {
            return Repository.GetGroupList(predicate, keySelector, @select, includes);
        }

        #endregion

        #region Create

        /// <inheritdoc cref="IBaseService{TEntity,TDto}.Create(TDto)"/>
        public virtual TDto Create(TDto model) {
            if (model == null) {
                throw new ArgumentNullException(nameof(model),
                    $"BaseService<{typeof(TEntity).FullName}, {typeof(TDto).FullName}> Create");
            }
            var entity = Mapper.Map<TDto, TEntity>(model);
            return Mapper.Map<TEntity, TDto>(Repository.Create(entity));
        }

        /// <inheritdoc cref="IBaseService{TEntity,TDto}.Create(List{TDto})"/>
        public virtual List<TDto> Create(List<TDto> models) {
            if (models == null) {
                throw new ArgumentNullException(nameof(models),
                    $"BaseService<{typeof(TEntity).FullName}, {typeof(TDto).FullName}> Create");
            }
            var entities = models.Select(Mapper.Map<TDto, TEntity>).ToList();
            return Repository.Create(entities).Select(Mapper.Map<TEntity, TDto>).ToList();
        }

        /// <inheritdoc cref="IBaseService{TEntity,TDto}.CreateBulk(List{TDto})"/>
        public virtual void CreateBulk(List<TDto> models) {
            if (models == null) {
                throw new ArgumentNullException(nameof(models),
                    $"BaseService<{typeof(TEntity).FullName}, {typeof(TDto).FullName}> Create");
            }
            var entities = models.Select(Mapper.Map<TDto, TEntity>).ToList();
            Repository.CreateBulk(entities);
        }

        #endregion

        #region Update

        /// <inheritdoc cref="IBaseService{TEntity,TDto}.Update(TDto)"/>
        public virtual TDto Update(TDto model) {
            if (model == null) {
                throw new ArgumentNullException(nameof(model),
                    $"BaseService<{typeof(TEntity).FullName}, {typeof(TDto).FullName}> Update");
            }
            var entity = Mapper.Map<TDto, TEntity>(model);
            return Mapper.Map<TEntity, TDto>(Repository.Update(entity));
        }

        /// <inheritdoc cref="IBaseService{TEntity,TDto}.Update(List{TDto})"/>
        public virtual List<TDto> Update(List<TDto> models) {
            if (models == null) {
                throw new ArgumentNullException(nameof(models),
                    $"BaseService<{typeof(TEntity).FullName}, {typeof(TDto).FullName}> Update");
            }
            var entities = models.Select(Mapper.Map<TDto, TEntity>).ToList();
            return Repository.Update(entities).Select(Mapper.Map<TEntity, TDto>).ToList();
        }

        /// <inheritdoc cref="IBaseService{TEntity,TDto}.Update(Expression{Func{TEntity, bool}}, IEnumerable{Expression{Func{TEntity, object}}}, Action{TEntity})"/>
        public virtual List<TDto> Update(Expression<Func<TEntity, bool>> predicate,
            IEnumerable<Expression<Func<TEntity, object>>> includes = null,
            Action<TEntity> action = null) {
            return Repository.Update(predicate, includes, action).Select(Mapper.Map<TEntity, TDto>).ToList();
        }

        #endregion

        #region Delete

        /// <inheritdoc cref="IBaseService{TEntity,TDto}.Delete"/>
        public virtual int Delete(Expression<Func<TEntity, bool>> predicate) {
            return Repository.Delete(predicate);
        }

        #endregion

        #region Count

        /// <inheritdoc cref="IBaseService{TEntity,TDto}.Count"/>
        public virtual int Count(Expression<Func<TEntity, bool>> predicate,
            IEnumerable<Expression<Func<TEntity, object>>> includes = null) {
            return Repository.Count(predicate, includes);
        }

        #endregion

    }
}
