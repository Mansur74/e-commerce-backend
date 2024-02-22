using Entities.Concretes;
using Microsoft.EntityFrameworkCore.Query;
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
        public ICollection<T> GetAll(Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, Expression<Func<T, bool>>? filter = null);
        public T? Get(Expression<Func<T, bool>> filter, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);
        public void Create(T entity);
        public void Update(T entity);
        public void Delete(T entity);
    }
}
