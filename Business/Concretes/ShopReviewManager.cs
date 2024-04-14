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
    public class ShopReviewManager : IShopReviewService
    {
        private readonly IShopReviewDal _shopReviewDal;
        private readonly IShopRateDal _shopRateDal;
        private readonly IUserDal _userDal;
        private readonly IShopDal _shopDal;
        private readonly IMapper _mapper;

        public ShopReviewManager(IShopReviewDal shopReviewDal, IUserDal userDal, IShopDal shopDal, IShopRateDal shopRateDal, IMapper mapper)
        {
            _userDal = userDal;
            _shopDal = shopDal;
            _shopReviewDal = shopReviewDal;
            _shopRateDal = shopRateDal;
            _mapper = mapper;
        }
        public Result Create(ShopReviewDto shopReviewDto, int userId, int shopId)
        {
            User? user = _userDal.Get(u => u.Id == userId);
            Shop? shop = _shopDal.Get(p => p.Id == shopId);
            ShopRate? rate = _shopRateDal.Get(sr => sr.UserId == userId && sr.ShopId == shopId);
            if (user == null)
                throw new NotFoundException("User does not exist");
            if (shop == null)
                throw new NotFoundException("Shop does not exist");
            if (rate == null)
                throw new NotFoundException("Shop rate does not exist");

            ShopReview shopReview = _mapper.Map<ShopReview>(shopReviewDto);
            shopReview.User = user;
            shopReview.Shop = shop;
            shopReview.Rate = rate;
            _shopReviewDal.Create(shopReview);

            return new SuccessResult("Shop review was created successfully");
        }

        public Result Delete(int Id)
        {
            ShopReview? productReview = _shopReviewDal.Get(sr => sr.Id == Id);
            if (productReview == null)
                throw new NotFoundException("Shop review does not exist");
            _shopReviewDal.Delete(productReview);
            return new SuccessResult("Shop review deleted successfully");
        }

        public DataResult<ICollection<ShopReviewDto>> GetAll()
        {
            ICollection<ShopReview> shopReviews = _shopReviewDal.GetAll();
            ICollection<ShopReviewDto> result = _mapper.Map<ICollection<ShopReviewDto>>(shopReviews);
            return new SuccessDataResult<ICollection<ShopReviewDto>>(result);
        }

        public DataResult<ShopReviewDto> GetById(int id)
        {
            ShopReview? shopReview = _shopReviewDal.Get(sr => sr.Id == id);
            ShopReviewDto result = _mapper.Map<ShopReviewDto>(shopReview);
            return new SuccessDataResult<ShopReviewDto>(result);
        }
    }
}
