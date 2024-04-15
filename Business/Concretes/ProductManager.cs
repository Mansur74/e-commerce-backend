using AutoMapper;
using Business.Abstracts;
using Core.Exceptions;
using Core.Utilities;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities.Concretes;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
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
        private readonly ICategoryDal _categoryDal;
        private readonly IProductCategoryDal _productCategoryDal;

        public ProductManager(IMapper mapper, IProductDal productDal, IShopDal shoptDal, ICategoryDal categoryDal, IProductCategoryDal productCategoryDal)
        {
            _mapper = mapper;
            _productDal = productDal;
            _shoptDal = shoptDal;
            _categoryDal = categoryDal;
            _productCategoryDal = productCategoryDal;
        }
        public Result Create(ProductDto productDto, int shopId, int categoryId)
        {
            Category? category = _categoryDal.Get(c => c.Id == categoryId);
            if (category == null)
                throw new NotFoundException("Category does not exist");

            Shop? shop = _shoptDal.Get(s => s.Id == shopId);
            if (shop == null)
                throw new NotFoundException("Shop does not exist");

            Product product = _mapper.Map<ProductDto, Product>(productDto);
            product.Shop = shop;
            _productDal.Create(product);

            ProductCategory pc = new ProductCategory
            {
                Product = product,
                Category = category,
            };
            _productCategoryDal.Create(pc);

            return new SuccessResult("Product was created successfully");
        }

        public Result Update(ProductDto productDto, int productId)
        {
            string email = SecurityUtil.getUserEmail();
            Product? product = _productDal.Get(p => p.Id == productId);
            if (product == null || product.Shop.User.Email != email)
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
            string email = SecurityUtil.getUserEmail();
            Product?  product = _productDal.Get(p => p.Id == id);
            if (product == null || product.Shop.User.Email != email)
                throw new NotFoundException("Product was already deleted");

            _productDal.Delete(product);
            return new SuccessResult("Product was deleted successfully");
        }

        public DataResult<ICollection<ProductDto>> GetAll()
        {
            ICollection<Product> products = _productDal.GetAll(p => p
            .Include(p => p.Shop)
            .Include(p => p.Rates)
            .ThenInclude(pr => pr.User)
            .Include(p => p.Reviews)
            .ThenInclude(pr => pr.Rate)
            .ThenInclude(pr => pr.User));
   

            ICollection<ProductDto> result = _mapper.Map<ICollection<ProductDto>>(products);
            return new SuccessDataResult<ICollection<ProductDto>>(result);
        }

        public DataResult<PageResult<ProductDto>> GetAllWithProductFilter(ProductFilterDto productFilter, int pageNumber, int pageSize)
        {
            PageResult<Product> pageResult = _productDal.GetAll(pageNumber, pageSize, 
                p => p
                .Include(p => p.Shop)
                .Include(p => p.Rates)
                .ThenInclude(pr => pr.User)
                .Include(p => p.Reviews)
                .ThenInclude(pr => pr.Rate)
                .ThenInclude(pr => pr.User), 
                p => p.Categories.Any(pc => productFilter.Categories.Contains(pc.Category.Name)) && productFilter.Colors.Contains(p.Color) && productFilter.Rates.Contains((int)p.Rates.Average(r => r.Rate)) && p.Name.ToLower().Contains(productFilter.Search.ToLower()));
            
            ICollection<ProductDto> products = _mapper.Map<ICollection<ProductDto>>(pageResult.rows);
            PageResult<ProductDto> result = new PageResult<ProductDto> { pageNo = pageResult.pageNo, pageSize = pageResult.pageSize, totalPages = pageResult.totalPages, rows = products};
            return new SuccessDataResult<PageResult<ProductDto>>(result);
        }

        public DataResult<ProductDto> GetById(int id)
        {
            Product? product = _productDal.Get(p => p.Id == id, p => p
            .Include(p => p.Shop)
            .ThenInclude(pr => pr.User)
            .Include(p => p.Rates)
            .ThenInclude(pr => pr.User)
            .Include(p => p.Reviews)
            .ThenInclude(pr => pr.Rate)
            .ThenInclude(pr => pr.User));
            if (product == null)
                throw new NotFoundException("Product does not exist");
            ProductDto result = _mapper.Map<ProductDto>(product);
            return new SuccessDataResult<ProductDto>(result);
        }
    }
}
