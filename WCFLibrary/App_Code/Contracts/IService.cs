using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using WcfLibrary.Domain.Dtos.CreateDTO;
using WcfLibrary.Domain.Dtos.ResponseDTO;
using WcfLibrary.Domain.Dtos.UpdateDTO;

[ServiceContract]
public interface IService
{

    [OperationContract]
    AuthorDTO GetUser(int id);
    [OperationContract]
    IEnumerable<UserDTO> GetUsers();
    [OperationContract]
    int CreateUser(AuthorCreateDTO dto);
    [OperationContract]
    bool UpdateAuthor(AuthorUpdateDTO authorDTO);
    [OperationContract]
    IEnumerable<AuthorDTO> SearchByName(string name);

}