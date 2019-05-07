using StarterKit.Contracts.Entities;
using StarterKit.SQLite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarterKit.SQLite
{
    public class UserRepository : IUserRepository
    {
        public IDBRepository<User> UserDBRepository;

        public UserRepository(IDBRepository<User> userDBRepository)
        {
            this.UserDBRepository = userDBRepository;
        }

        public int DeleteUser(User user)
        {
            return this.UserDBRepository.Delete(user);
        }

        public User GetUserByUserName(string userName)
        {
            var selectedUser = this.UserDBRepository.Get(x => x.UserName.Equals(userName));
            return selectedUser ?? null;
        }

        public int SaveUser(User user)
        {
            if (this.GetUserByUserName(user.UserName) != null)
                this.DeleteUser(user);

            return this.UserDBRepository.Insert(user);
        }

        public int UpdateUser(User user)
        {
            return this.UserDBRepository.Update(user);
        }
    }
}
