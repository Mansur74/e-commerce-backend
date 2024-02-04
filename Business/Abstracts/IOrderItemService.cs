using Core.Utilities.Results;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IOrderItemService
    {
        public DataResult<ICollection<OrderItemDto>> GetAll();
        public DataResult<OrderItemDto> GetById(int id);
        public Result Create(OrderItemDto orderItemDto, int productId, int orderId);
        public Result Update(OrderItemDto orderItemDto, int orderItemId);
        public Result Delete(int id);
    }
}
