﻿using Core.DataAccess;
using DataAccess.Abstracts;
using Entities.Concretes;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes
{
    public class ShopDal : Repository<Shop>, IShopDal
    {
        private readonly DataContext _dataContext;
        public ShopDal(DataContext dataContext) : base(dataContext) 
        {
            _dataContext = dataContext;
        }

    }
}
