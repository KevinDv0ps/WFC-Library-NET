using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WcfLibrary.Domain.Dtos.CreateDTO;
using WcfLibrary.Domain.Dtos.ResponseDTO;
using WcfLibrary.Domain.Dtos.UpdateDTO;

namespace WcfService1.Contracts
{
    [ServiceContract]
    public interface IAuthorServiceContract
    {
        [OperationContract]
        int CreateUser(AuthorCreateDTO dto);
        [OperationContract]
        bool UpdateAuthor(AuthorUpdateDTO authorDTO);
        [OperationContract]
        AuthorDTO GetUser(int id);
        [OperationContract]
        IEnumerable<AuthorDTO> GetUsers();
        [OperationContract]
        IEnumerable<AuthorDTO> SearchByName(string name);

    }
}
