using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Xpanxion.MicroService.Api.CloudServices.Azure.Interfaces
{
    public interface IFileStorageManager
    {
        Task AddFile(string fileName);
    }
}
