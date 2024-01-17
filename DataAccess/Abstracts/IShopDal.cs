using Entities.Concretes;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstracts
{
    public interface IShopDal
    {
        public Shop? CreateShop(Shop shop);
        public Shop? UpdateShop(Shop shop, int shopId);
        public ICollection<Shop> GelAllShops();
        public Shop? GetShopById(int shopId);
    }
}
