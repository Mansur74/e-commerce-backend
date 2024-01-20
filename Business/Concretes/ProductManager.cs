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
            Shop? shop = _shoptDal.Get(s => s.Id == shopId);
            if (shop == null)
                throw new NotFoundException("Shop does not exist");

            Product product = _mapper.Map<ProductDto, Product>(productDto);
            product.Shop = shop;
            _productDal.Create(product);
            return new SuccessResult("Product was created successfully");
        }

        public Result Update(ProductDto productDto, int productId)
        {
            Product? product = _productDal.Get(p => p.Id == productId);
            if (product == null)
                throw new NotFoundException("Product does not exist");

            product.Id = productDto.Id;
            product.Description = productDto.Description;
            product.Price = productDto.Price;
            product.SKU = productDto.SKU;
            product.Stock = productDto.Stock;
            _productDal.Create(product);
            return new SuccessResult("Product was updated successfully");
        }

        public Result Delete(int id)
        {
            Product?  product = _productDal.Get(p => p.Id == id);
            if (product == null)
                throw new NotFoundException("Product was already deleted");

            _productDal.Delete(product);
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
            Product? product = _productDal.Get(p => p.Id == id);
            if (product == null)
                throw new NotFoundException("Product does not exist");
            ProductDto result = _mapper.Map<ProductDto>(product);
            return new SuccessDataResult<ProductDto>(result);
        }
    }
}
