using System;
using System.Collections.Generic;
using System.Text;
using Xpanxion.MicroService.Api.DataAccess.Entities;

namespace Xpanxion.MicroService.Api.DataAccess.Repository.Interfaces
{
    public interface IUserRepository
    {
        bool RegisterNewUser(User user);

        User GetUserByUserName(string userName);

        User UpdateUser(User user);

    }
}
