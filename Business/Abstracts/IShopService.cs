using Core.Utilities.Results;
using Entities.Concretes;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IShopService
    {
        public DataResult<ICollection<ShopDto>> GetAll();
        public DataResult<PageResult<ShopDto>> GetPage(int pageNumber, int pageSize);
        public DataResult<ShopDto> GetById(int shopId);
        public Result Create(ShopDto shopDto, int userId);
        public Result Update(ShopDto shopDto, int shopId);
        public Result Delete(int id);
    }
}
