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
    public class CartManager : ICartService
    {
        private readonly ICartDal _cartDal;
        private readonly IProductDal _productDal;
        private readonly IUserDal _userDal;
        private readonly IMapper _mapper;
        public CartManager(ICartDal cartDal, IMapper mapper, IProductDal productDal, IUserDal userDal) 
        {
            _cartDal = cartDal;
            _productDal = productDal;
            _userDal = userDal;
            _mapper = mapper;
        }
        public Result Create(CartDto cartDto, int userId, int productId)
        {
            User? user = _userDal.Get(u => u.Id == userId);
            if (user == null)
                throw new NotFoundException("User does not exist");

            Product? product = _productDal.Get(p => p.Id == productId);
            if (product == null)
                throw new NotFoundException("Product does not exist");

            Cart cart = _mapper.Map<Cart>(cartDto);

            cart.User = user;
            cart.Product = product;

            _cartDal.Create(cart);
            return new SuccessResult("Cart was created successfully");
        }

        public DataResult<ICollection<CartDto>> GetAllCarts()
        {
            ICollection<Cart> carts = _cartDal.GetAllIncludes();
            ICollection<CartDto> result = _mapper.Map<ICollection<CartDto>>(carts);
            return new SuccessDataResult<ICollection<CartDto>>(result);
        }

        public Result Update(CartDto cartDto, int cartId)
        {
            Cart? cart = _cartDal.Get(c => c.Id == cartId);
            cart.Quantity = cartDto.Quantity;

            _cartDal.Update(cart);
            return new SuccessResult("Cart was updated successfully");
        }
    }
}
