using Core.DataAccess;
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
    public class UserDal : Repository<User>, IUserDal
    {
        private readonly DataContext _dbContext;
        public UserDal(DataContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateUserRole(UserRole userRole)
        {
            _dbContext.Add(userRole);
            _dbContext.SaveChanges();
        }

        public ICollection<User> GetAllIncludes()
        {
            return _dbContext.Users.Include(u => u.Roles).ThenInclude(ur => ur.Role).ToList();
        }

        public User? GetUserByEmail(string email)
        {
            User? user = _dbContext.Users.Where(u => u.Email.Equals(email)).Include(u => u.Roles).ThenInclude(ur => ur.Role).FirstOrDefault();
            return user;
        }

        public User? GetUserByUserName(string userName)
        {
            User? user = _dbContext.Users.Where(u => u.UserName.Equals(userName)).Include(u => u.Roles).ThenInclude(ur => ur.Role).FirstOrDefault();
            return user;
        }
    }
}
