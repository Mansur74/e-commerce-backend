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
    public class PaymentManager : IPaymentService
    {
        private readonly IMapper _mapper;
        private readonly IPaymentDal _paymentDal;
        private readonly IUserDal _userDal;
        public PaymentManager(IMapper mapper, IUserDal userDal, IPaymentDal paymentDal)
        {
            _mapper = mapper;
            _paymentDal = paymentDal;
            _userDal = userDal;
        }
        public Result Create(PaymentDto paymentDto, int userId)
        {
            User? user = _userDal.Get(u => u.Id == userId);
            if (user == null)
                throw new NotFoundException("User does not exists");

            Payment? payment = _mapper.Map<PaymentDto, Payment>(paymentDto);
            payment.User = user;
            _paymentDal.Create(payment);

            return new SuccessResult("Payment was created successfully");

        }

        public Result Delete(int id)
        {
            Payment? payment = _paymentDal.Get(s => s.Id == id);
            if (payment == null)
                throw new NotFoundException("Payment was already deleted");

            _paymentDal.Delete(payment);
            return new SuccessResult("Payment was deleted successfully");
        }

        public DataResult<ICollection<PaymentDto>> GetAll()
        {
            ICollection<Payment> payments = _paymentDal.GetAll();
            ICollection<PaymentDto> result = _mapper.Map<ICollection<PaymentDto>>(payments);
            return new SuccessDataResult<ICollection<PaymentDto>>(result);
        }

        public DataResult<PaymentDto> GetById(int id)
        {
            Payment? payment = _paymentDal.Get(p => p.Id == id);
            if (payment == null)
                throw new NotFoundException("Payment does not exist");

            PaymentDto result = _mapper.Map<PaymentDto>(payment);
            return new SuccessDataResult<PaymentDto>(result);
        }

        public Result Update(PaymentDto paymentDto, int shipmentId)
        {
            Payment? payment = _paymentDal.Get(s => s.Id == shipmentId);
            if (payment == null)
                throw new NotFoundException("Payment does not exist");

            payment.PaymentDate = paymentDto.PaymentDate;
            payment.PaymentMethod = paymentDto.PaymentMethod;

            _paymentDal.Update(payment);
            return new SuccessResult("Payment was updated successfully");
        }
    }
}
