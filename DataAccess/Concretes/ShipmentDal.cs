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
    public class ShipmentDal : Repository<Shipment>, IShipmentDal
    {
        public ShipmentDal(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
