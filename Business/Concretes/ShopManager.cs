using AutoMapper;
using Business.Abstracts;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public Result Create(ShopDto shopDto, int userId)
        {
            User? user = _userDal.Get(u => u.Id == userId);
            if (user == null)
                return new ErrorResult("User does not exists");

            Shop shop = _mapper.Map<Shop>(shopDto);
            shop.User = user;
            _shopDal.Create(shop);
            return new SuccessResult("Shop was created successfully");
        }

        public Result Delete(int id)
        {
            Shop? shop = _shopDal.Get(s => s.Id == id);
            if (shop == null)
                return new ErrorResult("Shop was already deleted");

            _shopDal.Delete(id);
            return new SuccessResult("Shop was removed successfully");
        }

        public DataResult<ICollection<ShopDto>> GelAll()
        {
            ICollection<Shop> shops = _shopDal.GetAll();
            ICollection<ShopDto> result = _mapper.Map<ICollection<ShopDto>>(shops);
            return new SuccessDataResult<ICollection<ShopDto>>(result);
        }

        public DataResult<ShopDto> GetById(int shopId)
        {
            Shop? shop = _shopDal.Get(s => s.Id == shopId);
            if (shop == null)
                return new ErrorDataResult<ShopDto>(null, "Shop does not exists");

            ShopDto result = _mapper.Map<ShopDto>(shop);
            return new SuccessDataResult<ShopDto>(result);
        }

    }
}
