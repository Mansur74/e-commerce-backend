using Core.Utilities.Results;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
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
        public ICollection<TEntity> GetAll(Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, Expression<Func<TEntity, bool>>? filter = null)
        {
            var query = _dataContext.Set<TEntity>().AsQueryable();

            if (include != null)
                query = include(query);

            return filter == null
                ? query.ToList()
                : query.Where(filter).ToList();
        }

        public PageResult<TEntity> GetAll(int pageNumber, int pageSize, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, Expression<Func<TEntity, bool>>? filter = null)
        {
            PageResult<TEntity> pageResult = new PageResult<TEntity> {pageNo = pageNumber, pageSize = pageSize};
            var query = _dataContext.Set<TEntity>().AsQueryable();

            if (include != null)
                query = include(query);

            pageResult.rows = filter == null
                ? query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList()
                : query.Where(filter).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            pageResult.totalPages = (int) Math.Round((decimal)(query.Where(filter).Count() / pageSize));

            return pageResult;
        }

        public TEntity? Get(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
        {
            var query = _dataContext.Set<TEntity>().AsQueryable();

            if (include != null)
                query = include(query);

            return query.Where(filter).SingleOrDefault();
        }

       
    }
}
