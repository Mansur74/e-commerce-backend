using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;
using Entities.Concretes;

namespace DataAccess.Abstracts
{
    public interface IUserDal : IRepository<User>
    {
        public void CreateUserRole(UserRole userRole);
        public User? GetUserByEmail(string email);
        public User? GetUserByUserName(string userName);
        public ICollection<User> GetAllIncludes();

    }
}
