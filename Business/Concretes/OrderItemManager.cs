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
    public class OrderItemManager : IOrderItemService
    {
        private readonly IMapper _mapper;
        private readonly IOrderItemDal _orderItemDal;
        private readonly IOrderDal _orderDal;
        private readonly IProductDal _productDal;
        public OrderItemManager(IOrderItemDal orderItemDal, IOrderDal orderDal, IProductDal productDal, IMapper mapper)
        {
            _mapper = mapper;
            _orderItemDal = orderItemDal;
            _orderDal = orderDal;
            _productDal = productDal;
        }

        public Result Create(OrderItemDto orderItemDto, int productId, int orderId)
        {
            Product? product = _productDal.Get(p => p.Id == productId);
            Order? order = _orderDal.Get(o => o.Id == orderId);
            
            if (product == null)
                throw new NotFoundException("Product does not exist");

            if (order == null)
                throw new NotFoundException("Order does not exist");

            OrderItem orderItem = _mapper.Map<OrderItem>(orderItemDto);
            _orderItemDal.Create(orderItem);

            return new SuccessResult("OrderItem created successfully");

        }

        public Result Delete(int id)
        {
            throw new NotImplementedException();
        }

        public DataResult<ICollection<OrderItemDto>> GetAll()
        {
            ICollection<OrderItem> orderItems = _orderItemDal.GetAll();
            ICollection<OrderItemDto> result = _mapper.Map<ICollection<OrderItemDto>>(orderItems);
            return new SuccessDataResult<ICollection<OrderItemDto>>(result);
        }

        public DataResult<OrderItemDto> GetById(int id)
        {
            OrderItem? orderItem = _orderItemDal.Get(o => o.Id == id);
            if (orderItem == null)
                throw new NotFoundException("OrderItem does not exist");

            OrderItemDto result = _mapper.Map<OrderItemDto>(orderItem);
            return new SuccessDataResult<OrderItemDto>(result);
        }

        public Result Update(OrderItemDto orderItemDto, int orderItemId)
        {
            OrderItem? orderItem = _orderItemDal.Get(oi => oi.Id == orderItemId);

            if (orderItem == null)
                throw new NotFoundException("OrderItem does not exist");

            orderItem.Price = orderItemDto.Price;
            orderItem.Quantity = orderItemDto.Quantity;

            _orderItemDal.Create(orderItem);

            return new SuccessResult("OrderItem created successfully");
        }
    }
}
