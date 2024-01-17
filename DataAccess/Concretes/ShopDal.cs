using DataAccess.Abstracts;
using Entities.Concretes;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes
{
    public class ShopDal : IShopDal
    {
        private readonly DataContext _dataContext;
        public ShopDal(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Shop? CreateShop(Shop shop)
        {
            _dataContext.Shops.Add(shop);
            _dataContext.SaveChanges();
            Shop? createdShop = _dataContext.Shops.Where(s => s.Id == shop.Id).FirstOrDefault();
            return createdShop;
        }

        public ICollection<Shop> GelAllShops()
        {
            ICollection<Shop> shops = _dataContext.Shops.ToList();
            return shops;
        }

        public Shop? GetShopById(int shopId)
        {
            Shop? shop = _dataContext.Shops.Where(s => s.Id == shopId).FirstOrDefault();
            return shop;
        }

        public Shop? UpdateShop(Shop body, int shopId)
        {
            Shop? shop = _dataContext.Shops.Where(s => s.Id == shopId).FirstOrDefault();
            if (shop != null)
            {
                shop.Name = body.Name;
                shop.Description = body.Description;
                _dataContext.SaveChanges();
            }
            return shop;
        }
    }
}
