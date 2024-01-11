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

        public User CreateUser(User user)
        {

            using (DataContext dbContext = new DataContext())
            {
                dbContext.Users.Add(user);
                dbContext.SaveChanges();
                return dbContext.Users.Where(u => u.Id == user.Id).FirstOrDefault();
            }

        }

        public ICollection<User> GetAllUsers()
        {
            using (DataContext dbContext = new DataContext())
            {
                ICollection<User> users = dbContext.Users.ToList();
                return users;
            }
            
        }

    }
}
