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
    public class RoleDal :Repository<Role>, IRoleDal
    {
 
        private readonly DataContext _dbContext;
        public RoleDal(DataContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }    
        public Role GetRoleByName(string name)
        {
            Role role = _dbContext.Roles.Where(r => r.Name == name).FirstOrDefault();
            return role;
        }
    }
}
