using System;
using System.Collections.Generic;
using System.Text;
using Xpanxion.MicroService.Api.DataAccess.Entities;
using Xpanxion.MicroService.Api.DataAccess.Repository.Interfaces;

namespace Xpanxion.MicroService.Api.DataAccess.Repository
{
    public class UserRepository : IUserRepository
    {
        public IDBUnitOfWork dbUnitOfWork;
        public IDBRepository<User> dbRepository;
        public DatabaseContext databaseContext;

        public UserRepository(IDBUnitOfWork unitOfWork,DatabaseContext context)
        {
            this.dbUnitOfWork = unitOfWork;
            this.databaseContext = context;
            this.dbRepository = this.dbUnitOfWork.Repository<User>();
        }

        public User GetUserByUserName(string userName)
        {
            return this.dbRepository.Get(user => user.UserName.Equals(userName));
        }

        public bool RegisterNewUser(User user)
        {
            bool retValue = (this.GetUserByUserName(user.UserName) == null);

            if (retValue)
            {
                this.dbRepository.Add(user);
                this.dbUnitOfWork.SaveChanges();
            }

            return retValue;
        }

        public User UpdateUser(User user)
        {
            if (this.GetUserByUserName(user.UserName) != null)
            {
                this.dbRepository.Update(user);
                this.dbUnitOfWork.SaveChanges();
            }
            else
                this.RegisterNewUser(user);

            return user;
        }
    }
}
