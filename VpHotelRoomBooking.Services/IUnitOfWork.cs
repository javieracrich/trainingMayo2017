using System;
using System.Threading.Tasks;
using VpHotelRoomBooking.Data;

namespace VpHotelRoomBooking.Services
{
    public interface IUnitOfWork : IDisposable
    {
        VpAppContext Context { get; }
        /// <summary>
        /// Saves all pending changes
        /// </summary>
        /// <returns>The number of objects in an Added, Modified, or Deleted state</returns>
        int Commit();
        Task<int> CommitAsync();
    }
}
