using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class, new()
    {
        private readonly DataContext _dataContext;
        public Repository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public void Create(TEntity entity)
        {
            var createdEntity = _dataContext.Entry(entity);
            createdEntity.State = EntityState.Added;
            _dataContext.SaveChanges();
        }
        public void Delete(TEntity entity)
        {
            var deletedEntity = _dataContext.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            _dataContext.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            var updatedEntity = _dataContext.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            _dataContext.SaveChanges();
        }
        public ICollection<TEntity> GetAll(Expression<Func<TEntity, bool>>? filter = null)
        {
            return filter == null
                ? _dataContext.Set<TEntity>().ToList()
                : _dataContext.Set<TEntity>().Where(filter).ToList();
        }

        public TEntity? Get(Expression<Func<TEntity, bool>> filter)
        {
           return _dataContext.Set<TEntity>().Where(filter).SingleOrDefault();
        }

       
    }
}
