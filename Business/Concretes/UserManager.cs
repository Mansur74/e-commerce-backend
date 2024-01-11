using Business.Abstracts;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            this._userDal = userDal;
        }

        public User CreateUser(User user)
        {
            return _userDal.CreateUser(user);
        }

        public ICollection<User> GetAllUsers()
        {
            return _userDal.GetAllUsers();
        }
    }
}
