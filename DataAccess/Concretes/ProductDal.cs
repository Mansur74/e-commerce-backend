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

      
    }
}
