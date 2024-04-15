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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class ShopManager : IShopService
    {
        private readonly IShopDal _shopDal;
        private readonly IUserDal _userDal;
        private readonly IMapper _mapper;
        public ShopManager(IShopDal shopDal, IUserDal userDal, IMapper mapper)
        {
            _shopDal = shopDal;
            _userDal = userDal;
            _mapper = mapper;
        }
        public Result Create(ShopDto shopDto, int userId)
        {
            User? user = _userDal.Get(u => u.Id == userId);
            if (user == null)
                throw new NotFoundException("User does not exists");

            Shop shop = _mapper.Map<Shop>(shopDto);
            shop.User = user;
            _shopDal.Create(shop);
            return new SuccessResult("Shop was created successfully");
        }

        public Result Delete(int id)
        {
            string email = SecurityUtil.getUserEmail();
            Shop? shop = _shopDal.Get(s => s.Id == id);
            if (shop == null || shop.User.Email != email)
                throw new NotFoundException("Shop was already deleted");

            _shopDal.Delete(shop);
            return new SuccessResult("Shop was removed successfully");
        }

        public DataResult<ICollection<ShopDto>> GetAll()
        {
            ICollection<Shop> shops = _shopDal.GetAll(s => s.Include(s => s.User));
            ICollection<ShopDto> result = _mapper.Map<ICollection<ShopDto>>(shops);
            return new SuccessDataResult<ICollection<ShopDto>>(result);
        }

        public DataResult<ShopDto> GetById(int shopId)
        {
            Shop? shop = _shopDal.Get(s => s.Id == shopId, 
                s => s
                .Include(s => s.User)
                .Include(s => s.Products)
                .ThenInclude(p => p.Rates)
                .Include(s => s.Rates)
                .Include(s=> s.Reviews));
            if (shop == null)
                throw new NotFoundException("Shop does not exist");

            ShopDto result = _mapper.Map<ShopDto>(shop);
            return new SuccessDataResult<ShopDto>(result);
        }

        public DataResult<PageResult<ShopDto>> GetPage(int pageNumber, int pageSize)
        {
            PageResult<Shop> pageResult = _shopDal.GetAll(pageNumber, pageSize,
               s => s
                .Include(s => s.User)
                .Include(s => s.Products)
                .ThenInclude(p => p.Rates)
                .Include(s => s.Rates)
                .Include(s => s.Reviews));
            
            ICollection<ShopDto> shops = _mapper.Map<ICollection<ShopDto>>(pageResult.rows);
            PageResult<ShopDto> result = new PageResult<ShopDto> { pageNo = pageResult.pageNo, pageSize = pageResult.pageSize, totalPages = pageResult.totalPages, rows = shops };
            return new SuccessDataResult<PageResult<ShopDto>>(result);
        }

        public Result Update(ShopDto shopDto, int shopId)
        {
            string email = SecurityUtil.getUserEmail();
            Shop? shop = _shopDal.Get(s => s.Id == shopId);

            if (shop == null || shop.User.Email != email)
                throw new NotFoundException("Shop does not exist");

            shop.Name = shopDto.Name;
            shop.Description = shopDto.Description;
            shop.FoundedAt = shopDto.FoundedAt;
            _shopDal.Update(shop);
            return new SuccessResult("Shop updated successfully");

        }
    }
}
