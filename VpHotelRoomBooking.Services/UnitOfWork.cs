using System;
using System.Threading.Tasks;
using VpHotelRoomBooking.Data;

namespace VpHotelRoomBooking.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private VpAppContext context = new VpAppContext();

        public UnitOfWork(VpAppContext ctx)
        {
            this.context = ctx;
        }

        public VpAppContext Context { get { return this.context; } }

        public int Commit()
        {
            return context.SaveChanges();
        }

        public Task<int> CommitAsync()
        {
            return context.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

}
