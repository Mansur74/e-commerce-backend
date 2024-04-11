using Core.Utilities.Results;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IProductRateService
    {
        public Result Create(ProductRateDto productRateDto, int userId, int productId);
        public Result Update(ProductRateDto productReviewDto, int userId, int productId);
        public DataResult<ICollection<ProductRateDto>> GetAll();
        public DataResult<ProductRateDto> GetById(int userId, int productId);
    }
}
