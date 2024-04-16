using Core.DataAccess;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Test.DataAccess
{
    public class ProductDalTests
    {
        DataContext _dbContext;
        private readonly IProductDal _productDal;
        public ProductDalTests() 
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: configuration.GetConnectionString("DefaultConnection"))
                .Options;

            _dbContext =  new DataContext(options);
            _productDal = new ProductDal(_dbContext);
        }

        [Fact]
        public void GetById()
        {
            Product product = CreateExample();
            Product foundedProduct = _productDal.Get(p => p.Id == product.Id);
            Assert.Equal("Test", foundedProduct.Name);
        }

        private Product CreateExample()
        {
            Product product = new Product { Name = "Test", Color = "", Description = "", ImgURL = "", SKU = "" };
            _dbContext.Add(product);
            _dbContext.SaveChanges();
            return product;
        }
    }
}
