using Core.DataAccess;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes
{
    public class OrderDal : Repository<Order>, IOrderDal
    {
        public OrderDal(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
