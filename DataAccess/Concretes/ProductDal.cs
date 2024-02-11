using Core.DataAccess;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes
{
    public class ProductDal : Repository<Product>, IProductDal
    {
        private readonly DataContext _dbContext;
        public ProductDal(DataContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public ICollection<Product> GetAllIncludes()
        {
            return _dbContext.Products
                .Include(p => p.Carts)
                .Include(p => p.Wishlists)
                .Include(p => p.OrderItems)
                .Include(p => p.Categories).ThenInclude(pc => pc.Category)
                .ToList();
        }

        public Product? GetIncludes(Expression<Func<Product, bool>>? filter = null)
        {
            return _dbContext.Products.Where(filter)
                .Include(p => p.Carts)
                .Include(p => p.Wishlists)
                .Include(p => p.OrderItems)
                .Include(p => p.Categories).ThenInclude(pc => pc.Category)
                .FirstOrDefault();
        }
    }
}
