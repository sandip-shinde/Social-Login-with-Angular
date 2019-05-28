using StarterKit.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarterKit.SQLite.Interfaces
{
    public interface IUserRepository
    {
        User GetUserByUserName(string userName);
        int SaveUser(User user);
        int UpdateUser(User user);
        int DeleteUser(User user);
    }
}
