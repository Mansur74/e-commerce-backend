using Core.Utilities.Results;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IProductService
    {
        public DataResult<ICollection<ProductDto>> GetAll();
        public DataResult<PageResult<ProductDto>> GetAllWithProductFilter(ProductFilterDto productFilter, int pageNumber, int pageSize);
        public DataResult<ProductDto> GetById(int id);
        public Result Create(ProductDto productDto, int shopId, int categoryId);
        public Result Update(ProductDto productDto, int productId);
        public Result Delete(int id);
    }
}
