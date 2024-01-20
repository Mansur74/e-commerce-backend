using Core.Utilities.Results;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IShipmentService
    {
        public DataResult<ICollection<ShipmentDto>> GetAll();
        public DataResult<ShipmentDto> GetById(int id);
        public Result Create(ShipmentDto productDto, int userId);
        public Result Update(ShipmentDto productDto, int shipmentId);
        public Result Delete(int id);
    }
}
