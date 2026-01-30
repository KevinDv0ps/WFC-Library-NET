using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfLibrary.Domain.Dtos.CreateDTO;
using WcfLibrary.Domain.Dtos.ResponseDTO;
using WcfLibrary.Domain.Dtos.UpdateDTO;

namespace WcfService1.Service
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IUserWebService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IUserWebService
    {
        [OperationContract]
        int CreateUser(UserCreateDTO userDTO);
        [OperationContract]
        IEnumerable<UserDTO> GetAll();
        [OperationContract]
        UserDTO GetByEmail(string mail);
        [OperationContract]
        UserDTO GetById(int id_user);
        [OperationContract]
        bool UpdateUser(UserUpdateDTO userDTO);
    }
}
