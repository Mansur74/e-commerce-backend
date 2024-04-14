using Core.Utilities.Results;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IShopReviewService
    {
        public Result Create(ShopReviewDto shopReviewDto, int userId, int shopId);
        public Result Delete(int Id);
        public DataResult<ICollection<ShopReviewDto>> GetAll();
        public DataResult<ShopReviewDto> GetById(int id);

    }
}
