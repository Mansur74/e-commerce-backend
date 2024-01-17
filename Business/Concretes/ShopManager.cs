using AutoMapper;
using Business.Abstracts;
using DataAccess.Abstracts;
using Entities.Concretes;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class ShopManager : IShopService
    {
        private readonly IShopDal _shopDal;
        private readonly IUserDal _userDal;
        private readonly IMapper _mapper;
        public ShopManager(IShopDal shopDal, IUserDal userDal, IMapper mapper)
        {
            _shopDal = shopDal;
            _userDal = userDal;
            _mapper = mapper;
        }
        public ShopDto CreateShop(ShopDto shopDto, int userId)
        {
            User? user = _userDal.GetUserById(userId);
            Shop shop = _mapper.Map<Shop>(shopDto);
            shop.User = user;
            Shop? createdShop = _shopDal.CreateShop(shop);
            return _mapper.Map<ShopDto>(createdShop);
        }

        public ICollection<ShopDto> GelAllShops()
        {
            ICollection<Shop> shops = _shopDal.GelAllShops();
            return _mapper.Map<ICollection<ShopDto>>(shops);
        }

        public ShopDto GetShopById(int shopId)
        {
            Shop? shop = _shopDal.GetShopById(shopId);
            return _mapper.Map<ShopDto>(shop);
        }

        public ShopDto UpdateShop(ShopDto shop, int shopId)
        {
            Shop? updatedShop = _shopDal.UpdateShop(_mapper.Map<Shop>(shop), shopId);
            return _mapper.Map<ShopDto>(updatedShop);
        }
    }
}
