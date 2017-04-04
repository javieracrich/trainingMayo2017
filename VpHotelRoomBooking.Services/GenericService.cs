using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using VpHotelRoomBooking.Domain;

namespace VpHotelRoomBooking.Services
{
    public class GenericService : IGenericService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly DbContext _ctx;

        public GenericService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _ctx = unitOfWork.Context;
        }

        public virtual T Get<T>(int id, string includeProperties = "") where T : BaseEntity
        {
            IQueryable<T> query = _ctx.Set<T>();

            query = query.Where(x => !x.IsDisabled.HasValue || !x.IsDisabled.Value);

            foreach (var includeProperty in includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            return query.Single(x => x.Id == id);
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns>The Created Entity Id</returns>
        public virtual int Create<T>(T entity) where T : BaseEntity
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            entity.Created = DateTime.UtcNow;
            _ctx.Set<T>().Add(entity);
            _unitOfWork.Commit();
            return entity.Id;
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities"></param>
        /// <returns>Rows Affected</returns>
        public virtual int CreateRange<T>(IEnumerable<T> entities) where T : BaseEntity
        {
            if (entities == null)
            {
                throw new ArgumentNullException(nameof(entities));
            }
            foreach (var entity in entities)
            {
                entity.Created = DateTime.UtcNow;
            }

            _ctx.Set<T>().AddRange(entities);
            return _unitOfWork.Commit();
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns>Affected Rows</returns>
        public virtual int Update<T>(T entity) where T : BaseEntity
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            if (entity.IsDisabled.HasValue && entity.IsDisabled.Value)
            {
                throw new ArgumentException("entity is disabled");
            }

            entity.Updated = DateTime.UtcNow;
            _ctx.Entry(entity).State = EntityState.Modified;
            return _unitOfWork.Commit();
        }

        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns>Created/Updated Entity Id</returns>
        public virtual int Upsert<T>(T entity) where T : BaseEntity
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            if (entity.IsDisabled.HasValue && entity.IsDisabled.Value)
            {
                throw new ArgumentException("entity is disabled");
            }

            if (entity.Id == 0)
            {
                entity.Created = DateTime.UtcNow;
                _ctx.Entry(entity).State = EntityState.Added;
                _ctx.Set<T>().Add(entity);
            }
            else
            {
                entity.Updated = DateTime.UtcNow;
                _ctx.Entry(entity).State = EntityState.Modified;
                _ctx.Set<T>().Update(entity);
            }

           

            _unitOfWork.Commit();

            return entity.Id;
        }

        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns>Created/Updated Entity Id</returns>
        public virtual async Task<int> UpsertAsync<T>(T entity) where T : BaseEntity
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            if (entity.IsDisabled.HasValue && entity.IsDisabled.Value)
            {
                throw new ArgumentException("entity is disabled");
            }

            if (entity.Id == 0)
            {
                entity.Created = DateTime.UtcNow;
                _ctx.Entry(entity).State = EntityState.Added;
                _ctx.Set<T>().Add(entity);
            }
            else
            {
                entity.Updated = DateTime.UtcNow;
                _ctx.Entry(entity).State = EntityState.Modified;
                _ctx.Set<T>().Update(entity);

            }


            return await _unitOfWork.CommitAsync();
        }

        public virtual int Count<T>(Expression<Func<T, bool>> filter = null) where T : BaseEntity
        {
            IQueryable<T> query = _ctx.Set<T>();

            query = query.Where(x => !x.IsDisabled.HasValue || !x.IsDisabled.Value);

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return query.Count();
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns>Affected Rows</returns>
        public virtual int Delete<T>(int id) where T : BaseEntity
        {
            var entityToDelete = Get<T>(id);
            if (entityToDelete == null)
            {
                throw new ArgumentNullException("entity");
            }
            _ctx.Set<T>().Remove(entityToDelete);
            return _unitOfWork.Commit();
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns>Affected Rows</returns>
        public virtual int Delete<T>(T entity) where T : BaseEntity
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _ctx.Set<T>().Remove(entity);
            return _unitOfWork.Commit();
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities"></param>
        /// <returns>Affected Rows</returns>
        public virtual int DeleteRange<T>(IEnumerable<T> entities) where T : BaseEntity
        {
            if (entities == null) throw new ArgumentNullException(nameof(entities));
            _ctx.Set<T>().RemoveRange(entities);
            return _unitOfWork.Commit();
        }

        /// <summary>
        /// Disables Entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns>Affected Rows</returns>
        public virtual int SoftDelete<T>(T entity) where T : BaseEntity
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            entity.Updated = DateTime.UtcNow;
            entity.IsDisabled = true;
            _ctx.Entry(entity).State = EntityState.Modified;
            return _unitOfWork.Commit();
        }

        public virtual IEnumerable<T> Find<T>(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "") where T : BaseEntity
        {
            IQueryable<T> query = _ctx.Set<T>();

            query = query.Where(x => !x.IsDisabled.HasValue || !x.IsDisabled.Value);

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            return query.ToList();
        }


        public virtual IEnumerable<T> GetAll<T>() where T : BaseEntity
        {
            return _ctx
                .Set<T>()
                .Where(x => !x.IsDisabled.HasValue || !x.IsDisabled.Value)
                .AsEnumerable();
        }


    }
}
