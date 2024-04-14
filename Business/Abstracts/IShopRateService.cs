using Core.Utilities.Results;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IShopRateService
    {
        public Result Create(ShopRateDto shopRateDto, int userId, int shopId);
        public Result Update(ShopRateDto shopRateDto, int userId, int shopId);
        public DataResult<ICollection<ShopRateDto>> GetAll();
        public DataResult<ShopRateDto> GetById(int userId, int shopId);
    }
}
