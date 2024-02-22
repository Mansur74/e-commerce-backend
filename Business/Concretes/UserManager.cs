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

        public Result Create(UserDto userDto)
        {
            Role? role = _roleDal.GetRoleByName("ADMIN");
            User user = _mapper.Map<User>(userDto);
            UserRole userRole = new UserRole { User = user, Role = role };
            _userDal.Create(user);
            _userDal.CreateUserRole(userRole);
            return new SuccessResult("User was created successfully");
        }

        public DataResult<ICollection<UserDto>> GetAll()
        {
            ICollection<User> users = _userDal.GetAllIncludes();
            ICollection<UserDto> result = _mapper.Map<ICollection<UserDto>>(users);
            return new SuccessDataResult<ICollection<UserDto>>(result);
        }

        public DataResult<UserDto> GetById(int id)
        {
            User? user = _userDal.Get(u => u.Id == id);
            if (user == null)
                throw new NotFoundException("User does not exist");

            UserDto result = _mapper.Map<UserDto>(user);
            return new SuccessDataResult<UserDto>(result);
        }

        public DataResult<UserDto> GetUserByEmail(string email)
        {
            User? user = _userDal.GetUserByEmail(email);
            if (user == null)
                throw new NotFoundException("User does not exist");

            UserDto result = _mapper.Map<UserDto>(user);
            return new SuccessDataResult<UserDto>(result);
        }
    }
}
