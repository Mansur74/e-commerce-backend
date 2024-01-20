using AutoMapper;
using Business.Abstracts;
using Core.Exceptions;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities.Concretes;
using Entities.Dtos;


namespace Business.Concretes
{
    public class OrderManager : IOrderService
    {
        private readonly IOrderDal _orderDal;
        private readonly IUserDal _userDal;
        private readonly IShipmentDal _shipmentDal;
        private readonly IMapper _mapper;
        public OrderManager(IOrderDal orderDal, IUserDal userDal, IShipmentDal shipmentDal, IMapper mapper)
        {
            _orderDal = orderDal;
            _userDal = userDal;
            _shipmentDal = shipmentDal;
            _mapper = mapper;
        }
        public Result Create(OrderDto orderDto, int userId, int shipmentId, int paymentId)
        {
            User? user = _userDal.Get(u => u.Id == userId);
            Shipment? shipment = _shipmentDal.Get(s => s.Id == shipmentId);

            if (user == null)
                throw new NotFoundException("User does not exist");

            if (shipment == null)
                throw new NotFoundException("Shipment does not exist");

            Order order = _mapper.Map<Order>(orderDto);
            order.User = user;
            order.Shipment = shipment;
            _orderDal.Create(order);
            return new SuccessResult("Order was created successfully");
        }

        public Result Delete(int id)
        {
            Order? order = _orderDal.Get(o => o.Id == id);
            if (order == null)
                throw new NotFoundException("Order does not exist");
            _orderDal.Delete(order);
            return new SuccessResult("Order removed successfully");
        }

        public DataResult<ICollection<OrderDto>> GetAll()
        {
            ICollection<Order> orders = _orderDal.GetAll();
            ICollection<OrderDto> result = _mapper.Map<ICollection<OrderDto>>(orders);
            return new SuccessDataResult<ICollection<OrderDto>>(result);
        }

        public DataResult<OrderDto> GetById(int id)
        {
            Order? order = _orderDal.Get(o => o.Id == id);
            if (order == null)
                throw new NotFoundException("Order does not exist");

            OrderDto result = _mapper.Map<OrderDto>(order); 
            return new SuccessDataResult<OrderDto>(result);
        }

        public Result Update(OrderDto orderDto, int orderId)
        {
            Order? order = _orderDal.Get(u => u.Id == orderId);
            if (order == null)
                throw new NotFoundException("Order does not exist");

            order.OrderDate = orderDto.OrderDate;
            order.TotalPrice = orderDto.TotalPrice;

            _orderDal.Update(order);
            return new SuccessResult("Order was updated successfully");
        }
    }
}
