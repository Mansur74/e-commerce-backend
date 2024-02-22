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
    public interface IUserService
    {
        public Result Create(UserDto user);
        public DataResult<ICollection<UserDto>> GetAll();
        public DataResult<UserDto> GetById(int id);
        public DataResult<UserDto> GetUserByEmail(string email);
    }
}
