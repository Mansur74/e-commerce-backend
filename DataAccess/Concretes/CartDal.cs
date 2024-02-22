using Core.DataAccess;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes
{
    public class CartDal : Repository<Cart>, ICartDal
    {
        private readonly DataContext _dataContext;
        public CartDal(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public ICollection<Cart> GetAllIncludes()
        {
            return _dataContext.Carts
                .Include(c => c.Product)
                .Include(c => c.User)
                .ToList();
        }
    }
}
