using Core.Utilities.Results;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IPaymentService
    {
        public DataResult<ICollection<PaymentDto>> GetAll();
        public DataResult<PaymentDto> GetById(int id);
        public Result Create(PaymentDto productDto, int userId);
        public Result Update(PaymentDto productDto, int shipmentId);
        public Result Delete(int id);
    }
}
