using AutoMapper;
using Business.Abstracts;
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
    public class ProductManager : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IProductDal _productDal;
        private readonly IShopDal _shoptDal;
        public ProductManager(IMapper mapper, IProductDal productDal, IShopDal shoptDal)
        {
            _mapper = mapper;
            _productDal = productDal;
            _shoptDal = shoptDal;
        }
        public Result Create(ProductDto productDto, int shopId)
        {
            Shop shop = _shoptDal.Get(s => s.Id == shopId);
            Product product = _mapper.Map<ProductDto, Product>(productDto);
            product.Shop = shop;
            _productDal.Create(product);
            return new SuccessResult("Product was created successfully");
        }

        public Result Delete(int id)
        {
            Product product = _productDal.Get(p => p.Id == id);
            if (product == null)
                return new ErrorResult("Product was already deleted");

            _productDal.Delete(id);
            return new SuccessResult("Product was deleted successfully");
        }

        public DataResult<ICollection<ProductDto>> GetAll()
        {
            ICollection<Product> products = _productDal.GetAll();
            ICollection<ProductDto> result = _mapper.Map<ICollection<ProductDto>>(products);
            return new SuccessDataResult<ICollection<ProductDto>>(result);
        }

        public DataResult<ProductDto> GetById(int id)
        {
            Product product = _productDal.Get(p => p.Id == id);
            ProductDto result = _mapper.Map<ProductDto>(product);
            return new SuccessDataResult<ProductDto>(result);
        }
    }
}
