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
    public class ProductRateManager : IProductRateService
    {
        private readonly IProductRateDal _productRateDal;
        private readonly IUserDal _userDal;
        private readonly IProductDal _productDal;
        private readonly IMapper _mapper;

        public ProductRateManager(IProductRateDal productRateDal, IUserDal userDal, IProductDal productDal, IMapper mapper)
        {
            _productRateDal = productRateDal;
            _userDal = userDal;
            _productDal = productDal;
            _mapper = mapper;
        }
        public Result Create(ProductRateDto productRateDto, int userId, int productId)
        {
            User? user = _userDal.Get(u => u.Id == userId);
            if (user == null)
                throw new NotFoundException("User does not exist");

            Product? product = _productDal.Get(p => p.Id == productId);
            if (product == null)
                throw new NotFoundException("Product does not exist");

            ProductRate productRate = _mapper.Map<ProductRate>(productRateDto);
            productRate.User = user;
            productRate.Product = product;
            _productRateDal.Create(productRate);

            return new SuccessResult("Product rate was created successfully");
        }

        public DataResult<ICollection<ProductRateDto>> GetAll()
        {
            ICollection<ProductRate> productRates = _productRateDal.GetAll();
            ICollection<ProductRateDto> result = _mapper.Map<ICollection<ProductRateDto>>(productRates);
            return new SuccessDataResult<ICollection<ProductRateDto>>(result);
        }

        public DataResult<ProductRateDto> GetById(int userId, int productId)
        {
            ProductRate? productRate = _productRateDal.Get(pr => pr.UserId == userId && pr.ProductId == productId);
            ProductRateDto result = _mapper.Map<ProductRateDto>(productRate);
            return new SuccessDataResult<ProductRateDto>(result);
        }

        public Result Update(ProductRateDto productRateDto, int userId, int productId)
        {
            ProductRate? productRate = _productRateDal.Get(pr => pr.UserId == userId && pr.ProductId == productId);

            if (productRate == null)
                throw new NotFoundException("Product rate does not exist");

            productRate.Rate = productRateDto.Rate;
            _productRateDal.Update(productRate);
            return new SuccessResult("Product rate was updated successfully");
        }
    }
}
