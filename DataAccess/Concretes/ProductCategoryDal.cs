using Core.DataAccess;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace DataAccess.Concretes
{
    public class ProductCategoryDal : Repository<ProductCategory>, IProductCategoryDal
    {
        public ProductCategoryDal(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
