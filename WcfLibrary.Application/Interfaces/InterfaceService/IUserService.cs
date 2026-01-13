using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfLibrary.Domain.Dtos.CreateDTO;
using WcfLibrary.Domain.Dtos.ResponseDTO;
using WcfLibrary.Domain.Dtos.UpdateDTO;

namespace WcfLibrary.Application.Interfaces.InterfaceService
{
    public interface IUserService
    {
        int CreateUser(UserCreateDTO userDTO);
        IEnumerable<UserDTO> GetAll();
        UserDTO GetByEmail(string mail);
        UserDTO GetById(int id_user);
        bool UpdateUser(UserUpdateDTO userDTO);
    }
}
