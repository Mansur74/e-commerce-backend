using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concretes;

namespace DataAccess.Abstracts
{
    public interface IUserDal
    {
        public User? CreateUser(User user);
        public ICollection<User> GetAllUsers();
        public User? GetUserById(int id);
        public User? GetUserByEmail(string email);

    }
}
