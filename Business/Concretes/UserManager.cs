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
        private readonly IUserDal _userDal;
        private readonly IRoleDal _roleDal;
        public UserManager(IUserDal userDal, IRoleDal roleDal)
        {
            _userDal = userDal;
            _roleDal = roleDal;
        }

        public DataResult<User> CreateUser(UserDto userDto)
        {
            User user = new User { 
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                UserName = userDto.UserName,
                Email = userDto.Email,
                Password = userDto.Password,
                Age = userDto.Age,
            };
            User createdUser = _userDal.CreateUser(user);
            return new SuccessDataResult<User>(createdUser);
        }

        public DataResult<ICollection<UserDto>> GetAllUsers()
        {
            ICollection<User> users = _userDal.GetAllUsers();

            ICollection<UserDto> userDtos = users.Select(user => new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Email = user.Email,
                Password = user.Password,
                Age = user.Age,

            }).ToList();

            return new SuccessDataResult<ICollection<UserDto>>(userDtos);

        }
    }
}
