using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfLibrary.Application.Interfaces.InterfaceRepository;
using WcfLibrary.Application.Interfaces.InterfaceService;
using WcfLibrary.Domain.Dtos.CreateDTO;
using WcfLibrary.Domain.Dtos.ResponseDTO;
using WcfLibrary.Domain.Dtos.UpdateDTO;
using WcfLibrary.Domain.Entities;

namespace WcfLibrary.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public int CreateUser(UserCreateDTO userDTO)
        {
            var emailExist = _userRepository.GetByEmail(userDTO.email);
            if (emailExist != null) return 0;

            var user = new User
            {
                first_name = userDTO.first_name,
                second_name = userDTO.second_name,
                first_lastname = userDTO.first_lastname,
                second_lastname = userDTO.second_lastname,
                email = userDTO.email,
                phone_number = userDTO.phone_number
            };
            _userRepository.CreateUser(user);
            return 1;
        }

        public IEnumerable<UserDTO> GetAll()
        {
            var users = _userRepository.GetAll();
            return users.Select(user => new UserDTO
            {
                id_user = user.id,
                first_name = user.first_name,
                second_name = user.second_name,
                first_lastname = user.first_lastname,
                second_lastname = user.second_lastname,
                email = user.email,
                phone_number = user.phone_number,
                register_date = user.register_date
            });
        }

        public UserDTO GetByEmail(string mail)
        {
            var user = _userRepository.GetByEmail(mail);
            if (user == null) return null;
            return new UserDTO
            {
                id_user = user.id,
                first_name = user.first_name,
                second_name = user.second_name,
                first_lastname = user.first_lastname,
                second_lastname = user.second_lastname,
                email = user.email,
                phone_number = user.phone_number,
                register_date = user.register_date
            };
        }

        public UserDTO GetById(int id_user)
        {
            var user = _userRepository.GetById(id_user);
            if (user == null) return null;
            return new UserDTO
            {
                id_user = user.id,
                first_name = user.first_name,
                second_name = user.second_name,
                first_lastname = user.first_lastname,
                second_lastname = user.second_lastname,
                email = user.email,
                phone_number = user.phone_number,
                register_date = user.register_date
            };
        }

        public bool UpdateUser(UserUpdateDTO userDTO)
        {
            var user = _userRepository.GetById(userDTO.id);
            if (user == null) return false;

            user.first_name = userDTO.first_name;
            user.second_name = userDTO.second_name;
            user.first_lastname = userDTO.first_lastname;
            user.second_lastname = userDTO.second_lastname;
            user.phone_number = userDTO.phone_number;
            user.email = userDTO.email;

            var email_exits = _userRepository.GetByEmail(userDTO.email);
            if (email_exits != null && email_exits.id != userDTO.id) return false;

            _userRepository.UpdateUser(user);

            return true;
        }
    }
}
