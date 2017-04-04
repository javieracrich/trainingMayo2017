using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VpHotelRoomBooking.Domain;

namespace VpHotelRoomBooking.Services
{
    public interface IGenericService
    {
        T Get<T>(int id, string includeProperties = "") where T : BaseEntity;

        /// <summary>
        /// Inserts entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns>Id of the inserted entity</returns>
        int Create<T>(T entity) where T : BaseEntity;


        /// <summary>
        /// Inserts entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities"></param>
        /// <returns>Rows Affected</returns>
        int CreateRange<T>(IEnumerable<T> entities) where T : BaseEntity;

        /// <summary>
        /// Updates Entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns>rows affected</returns>
        int Update<T>(T entity) where T : BaseEntity;

        /// <summary>
        /// Updates or Inserts Entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns>Id of the inserted/updated entity</returns>
        int Upsert<T>(T entity) where T : BaseEntity;


        /// <summary>
        /// Updates or Inserts Entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns>Id of the inserted/updated entity</returns>
        Task<int> UpsertAsync<T>(T entity) where T : BaseEntity;

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns>rows affected</returns>
        int Delete<T>(int id) where T : BaseEntity;


        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities"></param>
        /// <returns>rows affected</returns>
        int DeleteRange<T>(IEnumerable<T> entities) where T : BaseEntity;

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns>rows affected</returns>
        int Delete<T>(T entity) where T : BaseEntity;

        int Count<T>(Expression<Func<T, bool>> filter = null) where T : BaseEntity;

        IEnumerable<T> GetAll<T>() where T : BaseEntity;

        IEnumerable<T> Find<T>(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "") where T : BaseEntity;

    }
}
