using Core.DataAccess;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes
{
    public class ProductReviewDal : Repository<ProductReview>, IProductReviewDal
    {
        private readonly DataContext _dataContext;
        public ProductReviewDal(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }
    }
}
