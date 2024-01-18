using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public interface IRepository<T> where T : class, new()
    {
        public ICollection<T> GetAll(Expression<Func<T, bool>>? filter = null);
        public T Get(Expression<Func<T, bool>> filter);
        public void Create(T entity);
        public void Delete(int id);
    }
}
