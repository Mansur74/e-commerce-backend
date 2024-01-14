using AutoMapper;
using Business.Abstracts;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities.Concretes;
using Entities.Dtos;

namespace Business.Concretes
{
    public class UserManager : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserDal _userDal;
        private readonly IRoleDal _roleDal;
        public UserManager(IMapper mapper, IUserDal userDal, IRoleDal roleDal)
        {
            _mapper = mapper;
            _userDal = userDal;
            _roleDal = roleDal;
        }

        public DataResult<UserDto> CreateUser(UserDto userDto)
        {
            User createdUser = _userDal.CreateUser(_mapper.Map<User>(userDto));
            UserDto result = _mapper.Map<UserDto>(createdUser);
            return new SuccessDataResult<UserDto>(result);
        }

        public DataResult<ICollection<UserDto>> GetAllUsers()
        {
            ICollection<User> users = _userDal.GetAllUsers();
            ICollection<UserDto> result = _mapper.Map<ICollection<UserDto>>(users);
            return new SuccessDataResult<ICollection<UserDto>>(result);
        }
    }
}
