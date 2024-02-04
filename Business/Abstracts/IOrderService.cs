using Core.Utilities.Results;
using Entities.Concretes;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IOrderService
    {
        public DataResult<ICollection<OrderDto>> GetAll();
        public DataResult<OrderDto> GetById(int id);
        public Result Create(OrderDto orderDto, int userId, int shipmentId, int paymentId);
        public Result Update(OrderDto orderDto, int orderId);
        public Result Delete(int id);
    }
}
