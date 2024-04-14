using AutoMapper;
using Business.Abstracts;
using Core.Exceptions;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities.Concretes;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class ShopRateManager : IShopRateService
    {

        private readonly IShopRateDal _shopRateDal;
        private readonly IUserDal _userDal;
        private readonly IShopDal _shopDal;
        private readonly IMapper _mapper;

        public ShopRateManager(IShopRateDal shopRateDal, IUserDal userDal, IShopDal shopDal, IMapper mapper)
        {
            _shopRateDal = shopRateDal;
            _userDal = userDal;
            _shopDal = shopDal;
            _mapper = mapper;
        }
        public Result Create(ShopRateDto shopRateDto, int userId, int shopId)
        {
            User? user = _userDal.Get(u => u.Id == userId);
            if (user == null)
                throw new NotFoundException("User does not exist");

            Shop? shop = _shopDal.Get(p => p.Id == shopId);
            if (shop == null)
                throw new NotFoundException("Shop does not exist");

            ShopRate shopRate = _mapper.Map<ShopRate>(shopRateDto);
            shopRate.User = user;
            shopRate.Shop = shop;
            _shopRateDal.Create(shopRate);

            return new SuccessResult("Shop rate was created successfully");
        }

        public DataResult<ICollection<ShopRateDto>> GetAll()
        {
            ICollection<ShopRate> shopRates = _shopRateDal.GetAll();
            ICollection<ShopRateDto> result = _mapper.Map<ICollection<ShopRateDto>>(shopRates);
            return new SuccessDataResult<ICollection<ShopRateDto>>(result);
        }

        public DataResult<ShopRateDto> GetById(int userId, int shopId)
        {
            ShopRate? shopRate = _shopRateDal.Get(sr => sr.UserId == userId && sr.ShopId == shopId);
            ShopRateDto result = _mapper.Map<ShopRateDto>(shopRate);
            return new SuccessDataResult<ShopRateDto>(result);
        }

        public Result Update(ShopRateDto shopRateDto, int userId, int shopId)
        {
            ShopRate? shopRate = _shopRateDal.Get(sr => sr.UserId == userId && sr.ShopId == shopId);

            if (shopRate == null)
                throw new NotFoundException("Shop rate does not exist");

            shopRate.Rate = shopRateDto.Rate;
            _shopRateDal.Update(shopRate);
            return new SuccessResult("Shop rate was updated successfully");
        }
    }
}
