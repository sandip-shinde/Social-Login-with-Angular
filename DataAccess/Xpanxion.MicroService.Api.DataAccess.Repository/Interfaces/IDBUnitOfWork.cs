using System;
using System.Collections.Generic;
using System.Text;

namespace Xpanxion.MicroService.Api.DataAccess.Repository.Interfaces
{
    public interface IDBUnitOfWork
    {
        IDBRepository<T> Repository<T>() where T : class;

        void SaveChanges();
    }
}
