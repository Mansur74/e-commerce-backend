using AutoMapper;
using Business.Abstracts;
using Core.Exceptions;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;
using Entities.Dtos;


namespace Business.Concretes
{
    public class ProductReviewManager : IProductReviewService
    {

        private readonly IProductReviewDal _productReviewDal;
        private readonly IProductRateDal _productRateDal;
        private readonly IUserDal _userDal;
        private readonly IProductDal _productDal;
        private readonly IMapper _mapper;

        public ProductReviewManager(IProductReviewDal productReviewDal, IUserDal userDal, IProductDal productDal, IProductRateDal productRateDal, IMapper mapper)
        {
            _userDal = userDal;
            _productDal = productDal;
            _productReviewDal = productReviewDal;
            _productRateDal = productRateDal;
            _mapper = mapper;
        }
        public Result Create(ProductReviewDto productReviewDto, int userId, int productId)
        {
            User? user = _userDal.Get(u => u.Id == userId);
            Product? product = _productDal.Get(p => p.Id == productId);
            ProductRate? rate = _productRateDal.Get(pr => pr.UserId == userId && pr.ProductId == productId);
            if (user == null)
                throw new NotFoundException("User does not exist");
            if (product == null)
                throw new NotFoundException("Product does not exist");
            if (rate == null)
                throw new NotFoundException("Product rate does not exist");

            ProductReview productReview = _mapper.Map<ProductReview>(productReviewDto);
            productReview.User = user;
            productReview.Product = product;
            productReview.Rate = rate;
            _productReviewDal.Create(productReview);

            return new SuccessResult("Product review was created successfully");
        }

        public Result Delete(int reviewId)
        {
            ProductReview? productReview = _productReviewDal.Get(pr => pr.Id == reviewId);
            if (productReview == null)
                throw new NotFoundException("Product review does not exist");
            _productReviewDal.Delete(productReview);
            return new SuccessResult("Product review deleted successfully");
        }

        public DataResult<ICollection<ProductReviewDto>> GetAll()
        {
            ICollection<ProductReview> productReviews = _productReviewDal.GetAll();
            ICollection<ProductReviewDto> result = _mapper.Map<ICollection<ProductReviewDto>>(productReviews);
            return new SuccessDataResult<ICollection<ProductReviewDto>>(result);
        }

        public DataResult<ProductReviewDto> GetById(int id)
        {
            ProductReview? productReview = _productReviewDal.Get(pr => pr.Id == id);
            ProductReviewDto result = _mapper.Map<ProductReviewDto>(productReview);
            return new SuccessDataResult<ProductReviewDto>(result);
        }
    }
}
