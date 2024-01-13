using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes
{
    public class UserDal : IUserDal
    {
        private readonly DataContext _dbContext;
        public UserDal(DataContext dbContext)
        {
            _dbContext = dbContext;
        }
        public User CreateUser(User user)
        {
            Role role = _dbContext.Roles.Where(r => r.Name == "ADMIN").FirstOrDefault();
            UserRole usersRoles = new UserRole
            {
                User = user,
                Role = role
            };

            _dbContext.Users.Add(user);
            _dbContext.Add(usersRoles);
            _dbContext.SaveChanges();
            return _dbContext.Users.Where(u => u.Id == user.Id).FirstOrDefault();
        }

        public ICollection<User> GetAllUsers()
        {
            ICollection<User> users = _dbContext.Users.Include(u => u.Roles).ToList();
            return users;

        }

        public User GetUserByEmail(string email)
        {
            User user = _dbContext.Users.Where(u => u.Email.Equals(email)).FirstOrDefault();
            return user;

        }
    }
}
