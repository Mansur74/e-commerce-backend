﻿using Core.Utilities.Results;
using Entities.Concretes;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IShopService
    {
        public DataResult<ICollection<ShopDto>> GelAll();
        public DataResult<ShopDto> GetById(int shopId);
        public Result Create(ShopDto shop, int userId);
        public Result Delete(int id);
    }
}
