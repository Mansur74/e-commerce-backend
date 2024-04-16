using AutoMapper;
using Business.Abstracts;
using Business.Concretes;
using Core.Utilities;
using Core.Utilities.Mappers;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities.Concretes;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore.Query;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Test.Service
{
    public class ProductServiceTests
    {
        private readonly Mock<IProductDal> _productDal;
        private readonly Mock<IShopDal> _shopDal;
        private readonly Mock<ICategoryDal> _categoryDal;
        private readonly Mock<IProductCategoryDal> _productCategoryDal;
        private readonly IMapper _mapper;
        private readonly IProductService _productService;

        public ProductServiceTests()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            _mapper = configuration.CreateMapper();
            _productDal = new Mock<IProductDal>();
            _shopDal = new Mock<IShopDal>();
            _categoryDal = new Mock<ICategoryDal>();
            _productCategoryDal = new Mock<IProductCategoryDal>();
            _productService = new ProductManager(_mapper, _productDal.Object, _shopDal.Object, _categoryDal.Object, _productCategoryDal.Object);
        }

        [Fact]
        public void ProductService_GetById_ProductDto()
        {
            Product product = new Product { Id = 1};
            _productDal.Setup(productDal => productDal.Get(It.IsAny<Expression<Func<Product, bool>>>(), It.IsAny<Func<IQueryable<Product>, IIncludableQueryable<Product, object>>>())).Returns(product);
            DataResult<ProductDto> result = _productService.GetById(1);
            Assert.Equal(1, result.Data.Id);

        }
        [Fact]
        public void ProductService_Create_Result()
        {
            _categoryDal.Setup(categoryDal => categoryDal.Get(It.IsAny<Expression<Func<Category, bool>>>(), null)).Returns(new Mock<Category>().Object);
            _shopDal.Setup(shopDal => shopDal.Get(It.IsAny<Expression<Func<Shop, bool>>>(), null)).Returns(new Mock<Shop>().Object);

            _productDal.Setup(productDal => productDal.Create(new Mock<Product>().Object));
            _productCategoryDal.Setup(productCategoryDal => productCategoryDal.Create(new Mock<ProductCategory>().Object));

 
            Result result = _productService.Create(new Mock<ProductDto>().Object, 1, 1);
            Assert.True(result.Success);

        }



    }
}
