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
        public ShopDto CreateShop(ShopDto shop, int userId);
        public ShopDto UpdateShop(ShopDto shop, int shopId);
        public ICollection<ShopDto> GelAllShops();
        public ShopDto GetShopById(int shopId);
    }
}
