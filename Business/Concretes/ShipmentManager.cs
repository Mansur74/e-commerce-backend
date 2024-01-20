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
    public class ShipmentManager : IShipmentService
    {
        private readonly IMapper _mapper;
        private readonly IShipmentDal _shipmentDal;
        private readonly IUserDal _userDal;
        public ShipmentManager(IMapper mapper, IUserDal userDal, IShipmentDal shipmentDal)
        {
            _mapper = mapper;
            _shipmentDal = shipmentDal;
            _userDal = userDal;
        }
        public Result Create(ShipmentDto shipmentDto, int userId)
        {
            User? user = _userDal.Get(u => u.Id == userId);
            if(user == null)
                throw new NotFoundException("User does not exists");

            Shipment? shipment = _mapper.Map<ShipmentDto, Shipment>(shipmentDto);
            shipment.User = user;
            _shipmentDal.Create(shipment);

            return new SuccessResult("Shipment was created successfully");

        }

        public Result Delete(int id)
        {
            Shipment shipment = _shipmentDal.Get(s => s.Id == id);
            if (shipment == null)
                throw new NotFoundException("Shipment was already deleted");

            _shipmentDal.Delete(shipment);
            return new SuccessResult("Shipment was deleted successfully");
        }

        public DataResult<ICollection<ShipmentDto>> GetAll()
        {
            ICollection<Shipment> shipments = _shipmentDal.GetAll();
            ICollection<ShipmentDto> result = _mapper.Map<ICollection<ShipmentDto>>(shipments);
            return new SuccessDataResult<ICollection<ShipmentDto>>(result);
        }

        public DataResult<ShipmentDto> GetById(int id)
        {
            Shipment? shipment = _shipmentDal.Get(p => p.Id == id);
            if (shipment == null)
                throw new NotFoundException("Shipment does not exist");

            ShipmentDto result = _mapper.Map<ShipmentDto>(shipment);
            return new SuccessDataResult<ShipmentDto>(result);
        }

        public Result Update(ShipmentDto shipmentDto, int shipmentId)
        {
            Shipment? shipment = _shipmentDal.Get(s => s.Id == shipmentId);
            if (shipment == null)
                throw new NotFoundException("Shipment does not exist");

            shipment.ShipmentDate = shipmentDto.ShipmentDate;
            shipment.Address = shipmentDto.Address;
            shipment.City = shipmentDto.City;
            shipment.State = shipmentDto.State;
            shipment.Country = shipmentDto.Country;
            shipment.ZipCode = shipmentDto.ZipCode;

            _shipmentDal.Update(shipment);
            return new SuccessResult("Shipment was updated successfully");
        }
    }
}
