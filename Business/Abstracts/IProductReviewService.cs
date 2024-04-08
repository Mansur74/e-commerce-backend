using Core.Utilities.Results;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IProductReviewService
    {
        public Result Create(ProductReviewDto productReviewDto, int userId, int productId);
        public Result Delete(int reviewId);
        public DataResult<ICollection<ProductReviewDto>> GetAll();
        public DataResult<ProductReviewDto> GetById(int id);


    }
}
